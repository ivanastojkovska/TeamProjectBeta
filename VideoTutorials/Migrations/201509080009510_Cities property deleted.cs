namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Citiespropertydeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Cities_CityID", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Cities_CityID" });
            DropColumn("dbo.Users", "Cities_CityID");
            DropTable("dbo.Cities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            AddColumn("dbo.Users", "Cities_CityID", c => c.Int());
            CreateIndex("dbo.Users", "Cities_CityID");
            AddForeignKey("dbo.Users", "Cities_CityID", "dbo.Cities", "CityID");
        }
    }
}
