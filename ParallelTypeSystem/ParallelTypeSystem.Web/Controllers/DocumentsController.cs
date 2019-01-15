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
using System.Web.Mvc;

namespace ParallelTypeSystem.Web.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : Controller
    {
        private readonly IDbFactory dbFactory;
        private readonly IGenericRepository<File> fileRepository;

        public DocumentsController()
        {
            this.dbFactory = new DbFactory();
            this.fileRepository = new GenericRepository<File>(this.dbFactory);
        }

        [AllowAnonymous]
        public ActionResult ViewAll()
        {
            return View();
        }
        
        public ActionResult Editor()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddNewFile(AddFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "invalid data" }, JsonRequestBehavior.AllowGet);
            }

            var file = Mapper.Map<File>(viewModel);
            file.Guid = Guid.NewGuid().ToString();
            file.CreatorId = User.Identity.GetUserId();
            file.CreatedAt = DateTime.Now;

            this.fileRepository.Add(file);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
