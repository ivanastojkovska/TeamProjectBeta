namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                        Roles = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Link = c.String(),
                        Tags = c.String(),
                        Thumbnail = c.String(),
                        CategoryID = c.Int(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.VideoID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.CategoryID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Videos", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Videos", new[] { "User_UserID" });
            DropIndex("dbo.Videos", new[] { "CategoryID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Videos");
            DropTable("dbo.Users");
        }
    }
}
