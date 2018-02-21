using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using tofi2018.DAL;

namespace tofi2018.Models
{
    public enum Status
    {
        Pending,
        Approved,
        Rejected
    }

    public class Credit
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocsFolder { get; set; }

        public string PassportFile { get; set; }

        public string SalaryCertFile { get; set; }

        public decimal AnnualRate { get; set; }

        public int CreditId { get; set; }

        public decimal Sum { get; set; }

        public int Months { get; set; }

        public decimal MonthlyPayment { get; set; }

        public Status Status { get; set; }

        public void Calculate()
        {
            this.UserName = HttpContext.Current.User.Identity.Name;

            this.DocsFolder = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            this.Status = Status.Pending;

            this.MonthlyPayment =
                (this.AnnualRate * 0.01m / 12.0m * this.Months + 1m)
                * this.Sum / (decimal)this.Months;

            this.AddToDb();
        }

        public void AddToDb()
        {
            var root = HttpContext.Current.Server.MapPath(
                WebConfigurationManager.AppSettings["CreditsRootDirectory"]);

            using (var db = new CreditContext())
            {
                db.Credits.Add(this);
                db.SaveChanges();
            }
        }
    }

    public class UsersCreditsModel
    {
        public Dictionary<string, List<Credit>> AllCredits { get; private set; }

        public UsersCreditsModel()
        {
            this.AllCredits = new Dictionary<string, List<Credit>>();

            using (var usersContext = new ApplicationDbContext())
            using (var creditsContext = new CreditContext())
            {
                foreach (var u in usersContext.Users.Where(
                    u => u.Roles.Any(
                        r => r.RoleId == usersContext.Roles.Where(
                            i => i.Name == "User").FirstOrDefault().Id)))
                {
                    AllCredits.Add(u.Email, new List<Credit>());

                    foreach (var c in creditsContext.Credits.Where(
                        c => c.UserName == u.Email))
                    {
                        AllCredits[u.Email].Add(c);
                    }
                }
            }
        }
    }

    public class MyCreditsModel
    {
        public List<Credit> MyCredits { get; private set; }

        public MyCreditsModel(string userName)
        {
            this.MyCredits = new List<Credit>();

            using (var creditsContext = new CreditContext())
            {
                foreach (var c in creditsContext.Credits.Where(
                    c => c.UserName == userName))
                {
                    MyCredits.Add(c);
                }
            }
        }
    }
}
