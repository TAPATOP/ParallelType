using AutoMapper;
using Microsoft.AspNet.Identity;
using ParallelTypeSystem.Data;
using ParallelTypeSystem.Data.Repositories;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Services;
using ParallelTypeSystem.Web.Models;
using ParallelTypeSystem.Web.Utils;
using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using ParallelTypeSystem.Models.DTOs;

namespace ParallelTypeSystem.Web.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : Controller
    {
        private readonly ParallelTypeSystemDbContext dbContext;

        public DocumentsController()
        {
            this.dbContext = new DbFactory().GetContext();
        }
        
        // Id is the guid of the file
        public ActionResult Editor(string id)
        {
            var viewModel = new DocumentViewModel();

            viewModel.Files = this.GetAllUserFiles();
            if (string.IsNullOrEmpty(id))
            {
                return View(viewModel);
            }

            viewModel.IsSet = true;
            var file = this.dbContext.Files.FirstOrDefault(x => x.Guid == id);
            if (file != null)
            {
                var access = this.HasFileAccess(file, User.Identity.GetUserId());
                
                viewModel.Name = file.Name;
                viewModel.Content = this.CalculateContent(file.Id, file);
                return View(viewModel);
            }
            else
            {
                ViewBag.ErrorMessage = "No such file";
                return View(viewModel);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddNewFile(AddFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "invalid data" }, JsonRequestBehavior.AllowGet);
            }

            int version = 1;
            var file = Mapper.Map<File>(viewModel);
            file.Guid = Guid.NewGuid().ToString();
            file.CreatorId = User.Identity.GetUserId();
            file.CreatedAt = DateTime.Now;
            
            this.dbContext.Files.Add(file);

            var fileId = file.Id;
            var mainDirectory = Server.MapPath("~/App_Data/Files");
            if (!System.IO.Directory.Exists(mainDirectory))
            {
                System.IO.Directory.CreateDirectory(mainDirectory);
            }

            var directory = System.IO.Path.Combine(mainDirectory, User.Identity.GetUserName());
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            var filePath = this.GetFullFilePath(viewModel.Name, directory, version);
            System.IO.File.Create(filePath);

            var fileVersion = new FileVersion
            {
                FileId = fileId,
                Version = version,
                ModifiedAt = DateTime.Now,
                Directory = directory
            };

            this.dbContext.FileVersions.Add(fileVersion);
            this.dbContext.SaveChanges();

            return Json(new { success = true, guid = file.Guid }, JsonRequestBehavior.AllowGet);
        }

        private string GetFullFilePath(string filename, string directory, int version)
        {
            var path = System.IO.Path.Combine(directory, filename + "_" + version + ".txt");
            return path;
        }

        private string GetFullFilePath(FileVersion fileVersion)
        {
            var directory = fileVersion.Directory;
            var fileName = fileVersion.File.Name;
            var version = fileVersion.Version;
            var result = this.GetFullFilePath(fileName, directory, version);
            return result;
        }

        private string CalculateContent(int fileId, File file)
        {
            var query = this.dbContext.FileVersions
                .Where(x => x.FileId == fileId)
                .OrderBy(x => x.Version);

            var fileVersion = query.FirstOrDefault();

            StringBuilder sb = new StringBuilder();
            var filePath = this.GetFullFilePath(fileVersion);
            var originalContent = System.IO.File.ReadAllText(filePath);
            sb.Append(originalContent);

            if (string.IsNullOrEmpty(fileVersion.Changes))
            {
                return sb.ToString();
            }

            var changesViewModel = JsonConvert.DeserializeObject<ChangesViewModel>(fileVersion.Changes);
            foreach (var change in changesViewModel.Changes)
            {
                switch (change.ChangeType)
                {
                    case ChangeType.Add:
                        sb.Insert(change.Position, change.Value);
                        break;
                    case ChangeType.Delete:
                        sb.Remove(change.Position, change.Value.Length);
                        break;
                }
            }

            string result = sb.ToString();
            return result;
        }

        // 1-> can read, can write
        private Tuple<bool, bool> HasFileAccess(File file, string userId)
        {
            if (file.CreatorId == userId)
            {
                return new Tuple<bool, bool>(true, true);
            }

            if (file.PublicReadAll)
            {
                return new Tuple<bool, bool>(true, file.PublicWriteAll);
            }
            
            var usersFile = this.dbContext.UsersFiles.FirstOrDefault(x => x.FileId == file.Id && x.UserId == userId);
            if (usersFile == null)
            {
                return new Tuple<bool, bool>(false, false);
            }

            if (usersFile.PermissionTypeId == 1)
            {
                // 1: Read
                return new Tuple<bool, bool>(true, false);
            }
            else
            {
                // 2: Read and write
                return new Tuple<bool, bool>(true, true);
            }
        }

        private List<FileDTO> GetAllUserFiles()
        {
            var userId = User.Identity.GetUserId();
            var files = this.dbContext.UsersFiles.Include("Files")
                .Where(x => x.UserId == userId)
                .Select(x => new FileDTO
                {
                    Guid = x.File.Guid,
                    Name = x.File.Name,
                });

            var createdFiles = this.dbContext.Files
                .Where(x => x.CreatorId == userId)
                .Select(x => new FileDTO
                {
                    Guid = x.Guid,
                    Name = x.Name,
                });

            var result = files.Union(createdFiles).ToList();
            return result;
        }
    }
}
