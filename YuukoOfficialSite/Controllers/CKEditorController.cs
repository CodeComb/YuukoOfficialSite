using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace YuukoOfficialSite.Controllers
{
    [Authorize]
    public class CKEditorController : Controller
    {
        // GET: CKEditor
        [HttpPost]
        public ActionResult Upload(string CKEditorFuncNum, HttpPostedFileBase upload)
        {
            ViewBag.FuncName = CKEditorFuncNum;
            byte[] bytes;
            using (MemoryStream mem = new MemoryStream())
            {
                upload.InputStream.CopyTo(mem);
                bytes = mem.ToArray();
            }
            ViewBag.URI = string.Format("data:{0};base64,{1}", upload.ContentType, Convert.ToBase64String(bytes));
            return View();
        }
    }
}