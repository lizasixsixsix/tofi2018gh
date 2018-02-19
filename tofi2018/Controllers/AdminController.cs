using System.Web.Mvc;
using tofi2018.Models;

namespace tofi2018.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var allCredits = new UsersCreditsModel();

            return View(allCredits);
        }
    }
}
