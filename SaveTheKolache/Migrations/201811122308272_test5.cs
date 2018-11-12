namespace SaveTheKolache.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaigns", "CampaignInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaigns", "CampaignInfo");
        }
    }
}
