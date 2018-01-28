using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using tofi2018.Models;

namespace tofi2018.Controllers
{
    public class FileController : Controller
    {
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string fileName = string.Empty;

            if (file != null && file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);

                string now = DateTime.Now.ToString("o");

                var directory = Directory.CreateDirectory(
                    Path.Combine(Server.MapPath("~/App_Data/Uploaded"),
                                 DateTime.Now.ToString("yyyyMMddHHmmssffffff")));

                var path = Path.Combine(directory.FullName, fileName);

                file.SaveAs(path);

                return RedirectToAction("Uploaded", new { file = fileName });
            }

            return RedirectToAction("NotUploaded");
        }

        public ActionResult Uploaded(string file)
        {
            ViewBag.FileName = file;

            return View();
        }

        public ActionResult NotUploaded()
        {
            return View();
        }

        public ActionResult Download()
        {
            var dir = new DirectoryModel(Server.MapPath("~/App_Data/Uploaded/"));

            return View(dir);
        }

        public ActionResult DownloadFile(string fileName)
        {
            string contentType = "application/pdf";

            return File(fileName, contentType, Path.GetFileName(fileName));
        }
    }
}
