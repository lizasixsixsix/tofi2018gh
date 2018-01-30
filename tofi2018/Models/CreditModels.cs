using System;
using System.Collections.Generic;
using System.Linq;
using tofi2018.DAL;

namespace tofi2018.Models
{
    public class Credit
    {
        public decimal AnnualRate { get; set; }

        public int CreditID { get; set; }

        public decimal Sum { get; set; }

        public int Months { get; set; }

        public decimal MonthlyPayment { get; set; }

        public void Calculate()
        {
            this.MonthlyPayment = this.Sum * (this.AnnualRate * 0.01m +
                (this.AnnualRate * 0.01m /
                (decimal)Math.Pow((double)(1 + this.AnnualRate * 0.01m), this.Months)));
        }

        public void AddToDb()
        {
            using (var db = new CreditContext())
            {
                db.Credits.Add(this);
                db.SaveChanges();
            }
        }

        public void GetPayment()
        {
            using (var context = new CreditContext())
            {
                var credits = context.Credits;

                this.MonthlyPayment = credits.Where(c => c.Months == this.Months
                                                  && c.Sum == this.Sum)
                                      .First().MonthlyPayment;
            }
        }
    }

    public class MyCredits
    {
        Dictionary<int, Credit> Credits { get; set; }

        public MyCredits()
        {
            this.Credits = new Dictionary<int, Credit>();
        }
    }
}
