namespace tofi2018.Models
{
    public class CreditModel
    {
        public decimal Sum { get; set; }

        public int Months { get; set; }

        public decimal Payment { get; set; }

        public void Calculate()
        {
            this.Payment = this.Sum / this.Months;
        }
    }
}
