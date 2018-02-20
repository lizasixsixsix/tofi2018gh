namespace tofi2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusAsEnumeration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credits", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Credits", "IsApproved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Credits", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Credits", "Status");
        }
    }
}
