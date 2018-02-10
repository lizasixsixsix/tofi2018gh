namespace tofi2018.Migrations
{
    using System.Data.Entity.Migrations;
    using tofi2018.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<CreditContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "tofi2018.DAL.CreditContext";
        }

        protected override void Seed(CreditContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
