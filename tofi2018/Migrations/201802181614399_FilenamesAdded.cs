namespace tofi2018.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilenamesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Credits", "PassportFile", c => c.String());
            AddColumn("dbo.Credits", "SalaryCertFile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Credits", "SalaryCertFile");
            DropColumn("dbo.Credits", "PassportFile");
        }
    }
}
