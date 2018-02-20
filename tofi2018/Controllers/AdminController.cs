using System.Linq;
using System.Web.Mvc;
using tofi2018.DAL;
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

        public ActionResult Approve(int creditId)
        {
            using (var context = new CreditContext())
            {
                Credit credit = context.Credits.Where(
                    c => c.CreditID == creditId).First();

                credit.Status = Status.Approved;

                context.SaveChanges();
            }

            return View();
        }

        public ActionResult Reject(int creditId)
        {
            using (var context = new CreditContext())
            {
                Credit credit = context.Credits.Where(
                    c => c.CreditID == creditId).First();

                credit.Status = Status.Rejected;

                context.SaveChanges();
            }

            return View();
        }
    }
}
