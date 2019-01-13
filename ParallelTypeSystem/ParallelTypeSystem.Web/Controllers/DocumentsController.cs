using ParallelTypeSystem.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParallelTypeSystem.Web.Controllers
{
    [CustomAuthorize]
    public class DocumentsController : Controller
    {
        [AllowAnonymous]
        public ActionResult ViewAll()
        {
            return View();
        }
        
        public ActionResult Editor()
        {
            return View();
        }
    }
}
