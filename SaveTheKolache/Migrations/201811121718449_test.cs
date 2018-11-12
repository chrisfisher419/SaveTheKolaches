namespace SaveTheKolache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignID = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(),
                        Category = c.String(),
                        UsersSignedUp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignID);
            
            CreateTable(
                "dbo.SignUpLists",
                c => new
                    {
                        SignID = c.Int(nullable: false, identity: true),
                        CampaignID = c.Int(nullable: false),
                        CampaignName = c.String(),
                        UserID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateSigned = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SignID)
                .ForeignKey("dbo.Campaigns", t => t.CampaignID, cascadeDelete: true)
                .ForeignKey("dbo.UserProfileInfoes", t => t.UserID, cascadeDelete: true)
                .Index(t => t.CampaignID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SignUpLists", "UserID", "dbo.UserProfileInfoes");
            DropForeignKey("dbo.SignUpLists", "CampaignID", "dbo.Campaigns");
            DropIndex("dbo.SignUpLists", new[] { "UserID" });
            DropIndex("dbo.SignUpLists", new[] { "CampaignID" });
            DropTable("dbo.SignUpLists");
            DropTable("dbo.Campaigns");
        }
    }
}
