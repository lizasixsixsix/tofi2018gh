using System.Data.Entity;
using tofi2018.Models;

namespace tofi2018.DAL
{
    public class CreditContext : DbContext
    {
        public CreditContext() : base("name=tofi2018.Local")
        {
        }

        public DbSet<Credit> Credits { get; set; }
    }
}
