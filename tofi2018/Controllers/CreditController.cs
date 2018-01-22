using System.Web.Mvc;
using tofi2018.Models;

namespace tofi2018.Controllers
{
    public class CreditController : Controller
    {
        // GET: Credit
        public ActionResult Index()
        {
            return View();
        }

        // POST: Credit/Result
        [HttpPost]
        public ActionResult Result(Credit creditModel)
        {
            creditModel.Calculate();

            creditModel.AddToDb();

            creditModel.GetPayment();

            return View(creditModel);
        }
    }
}
