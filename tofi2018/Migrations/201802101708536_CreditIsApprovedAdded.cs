namespace tofi2018.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreditIsApprovedAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credits", "IsApproved", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Credits", "IsApproved");
        }
    }
}
