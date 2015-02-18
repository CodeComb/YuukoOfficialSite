using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YuukoOfficialSite.Controllers
{
    public class DocumentsController : Controller
    {
        // GET: Documents
        [Route("documents/{id?}")]
        public ActionResult Index(int? id)
        {
            return View();
        }
    }
}