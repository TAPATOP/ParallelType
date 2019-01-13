using AutoMapper;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ParallelTypeSystem.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Documents")]
    public class ApiDocumentsController : ApiController
    {
        private readonly IDocumentService documentService;

        public ApiDocumentsController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        [HttpPost]
        [Route(nameof(AddNewFile))]
        public IHttpActionResult AddNewFile(AddFileViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var file = Mapper.Map<File>(viewModel);
            file.Guid = Guid.NewGuid().ToString();
            file.CreatorId = User.Identity.GetUserId();
            file.CreatedAt = DateTime.Now;

            this.documentService.AddFile(file);

            return Ok();
        }
    }
}