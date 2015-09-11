namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermodelchanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "FormalEducation", c => c.String());
            AddColumn("dbo.Users", "Courses", c => c.String());
            AddColumn("dbo.Users", "ProfesionalExperience", c => c.String());
            AddColumn("dbo.Users", "EnrollmentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Cities_CityID", c => c.Int());
            CreateIndex("dbo.Users", "Cities_CityID");
            AddForeignKey("dbo.Users", "Cities_CityID", "dbo.Cities", "CityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Cities_CityID", "dbo.Cities");
            DropIndex("dbo.Users", new[] { "Cities_CityID" });
            DropColumn("dbo.Users", "Cities_CityID");
            DropColumn("dbo.Users", "EnrollmentDate");
            DropColumn("dbo.Users", "ProfesionalExperience");
            DropColumn("dbo.Users", "Courses");
            DropColumn("dbo.Users", "FormalEducation");
            DropColumn("dbo.Users", "DateOfBirth");
            DropTable("dbo.Cities");
        }
    }
}
