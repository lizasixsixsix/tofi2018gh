using System.Web.Mvc;
using tofi2018.Models;

namespace tofi2018.Controllers
{
    [Authorize(Roles = "User")]
    public class CreditController : Controller
    {
        // GET: Credit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Credit/My
        public ActionResult My()
        {
            return View();
        }

        // POST: Credit/Result
        [HttpPost]
        public ActionResult Result(Credit creditModel)
        {
            creditModel.Calculate();

            return View(creditModel);
        }
    }
}
