using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using tofi2018.DAL;
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

        public ActionResult UploadDocs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadDocs(HttpPostedFileBase passport,
                                       HttpPostedFileBase salaryCert)
        {
            string dirName = String.Empty;

            Credit credit;

            using (var context = new CreditContext())
            {
                var credits = context.Credits;

                credit = credits.Where(
                    c => c.UserName == System.Web.HttpContext.Current.User.Identity.Name).OrderByDescending(c => c.DocsFolder).First();

                dirName = credit.DocsFolder;

                var directory = Directory.CreateDirectory(
                    Path.Combine(
                        Server.MapPath(
                            WebConfigurationManager.AppSettings["CreditsRootDirectory"]),
                        dirName));

                var passportDirectory = Directory.CreateDirectory(
                    Path.Combine(directory.FullName, "passport"));

                var salaryCertDirectory = Directory.CreateDirectory(
                    Path.Combine(directory.FullName, "salary_cert"));

                passport.SaveAs(Path.Combine(passportDirectory.FullName,
                                   Path.GetFileName(passport.FileName)));

                salaryCert.SaveAs(Path.Combine(salaryCertDirectory.FullName,
                                     Path.GetFileName(salaryCert.FileName)));

                credit.PassportFile = Directory.GetFiles(
                    Path.Combine(directory.FullName, "passport")).First();

                credit.SalaryCertFile = Directory.GetFiles(
                    Path.Combine(directory.FullName, "salary_cert")).First();

                context.SaveChanges();
            }

            return RedirectToAction("DocsUploaded", "File");
        }

        public ActionResult DocsUploaded()
        {
            return View();
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

        // public ActionResult Download()
        // {
        //     var dir = new DirectoryModel(Server.MapPath("~/App_Data/Uploaded/"));

        //     return View(dir);
        // }

        public ActionResult DownloadFile(string fileName)
        {
            string contentType = "application/pdf";

            return File(fileName, contentType, Path.GetFileName(fileName));
        }
    }
}
