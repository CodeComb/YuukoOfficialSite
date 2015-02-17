using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YuukoOfficialSite.Controllers
{
    public class SamplesController : Controller
    {
        // GET: Samples
        public ActionResult Index()
        {
            return View();
        }

        [Route("samples/{id}")]
        public ActionResult Show(int id)
        {
            return View();
        }
    }
}