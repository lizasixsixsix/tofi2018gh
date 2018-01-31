using System;
using System.Web;
using tofi2018.DAL;

namespace tofi2018.Models
{
    public class Credit
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocsFolder { get; set; }

        public decimal AnnualRate { get; set; }

        public int CreditID { get; set; }

        public decimal Sum { get; set; }

        public int Months { get; set; }

        public decimal MonthlyPayment { get; set; }

        public void Calculate()
        {
            this.UserName = HttpContext.Current.User.Identity.Name;

            this.DocsFolder = DateTime.Now.ToString("yyyyMMddHHmmssffffff");

            this.MonthlyPayment = this.Sum * (this.AnnualRate * 0.01m +
                (this.AnnualRate * 0.01m /
                (decimal)Math.Pow((double)(1 + this.AnnualRate * 0.01m), this.Months)));

            this.AddToDb();
        }

        public void AddToDb()
        {
            using (var db = new CreditContext())
            {
                db.Credits.Add(this);
                db.SaveChanges();
            }
        }
    }
}
