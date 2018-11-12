namespace SaveTheKolache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfileInfoes", "Activity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfileInfoes", "Activity", c => c.Boolean(nullable: false));
        }
    }
}
