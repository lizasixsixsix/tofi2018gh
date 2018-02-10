namespace tofi2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DocsFolder = c.String(),
                        AnnualRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Months = c.Int(nullable: false),
                        MonthlyPayment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CreditID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Credits");
        }
    }
}
