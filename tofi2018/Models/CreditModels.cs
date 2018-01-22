using System.Linq;
using tofi2018.DAL;

namespace tofi2018.Models
{
    public class Credit
    {
        public int CreditID { get; set; }

        public decimal Sum { get; set; }

        public int Months { get; set; }

        public decimal Payment { get; set; }

        public void Calculate()
        {
            this.Payment = this.Sum / this.Months;
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

                this.Payment = credits.Where(c => c.Months == this.Months
                                                  && c.Sum == this.Sum)
                                      .First().Payment;
            }
        }
    }
}
