namespace SaveTheKolache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SignUpLists", "DateSigned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SignUpLists", "DateSigned", c => c.DateTime(nullable: false));
        }
    }
}
