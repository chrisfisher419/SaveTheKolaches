namespace SaveTheKolache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class news : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfileInfoes", "Activity", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfileInfoes", "Activity");
        }
    }
}
