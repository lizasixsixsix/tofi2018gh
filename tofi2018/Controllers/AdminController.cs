using System.Web.Mvc;

namespace tofi2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var dir = new Models.DirectoryModel(Server.MapPath("~/App_Data/Uploaded/"));

            return View(dir);
        }
    }
}
