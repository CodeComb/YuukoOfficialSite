using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Configuration;

namespace YuukoOfficialSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "admin");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Username, string Password)
        {
            if (Username == ConfigurationManager.AppSettings["Username"].ToString() && Password == ConfigurationManager.AppSettings["Password"])
            {
                FormsAuthentication.SetAuthCookie(Username, true);
                if (Request.UrlReferrer == null)
                    return Redirect("/");
                else
                    return Redirect(Request.UrlReferrer.ToString());
            }
            return View();
        }

        public ActionResult Sample(int? id)
        {
            return View();
        }

        public ActionResult Log(int? id)
        {
            return View();
        }
    }
}