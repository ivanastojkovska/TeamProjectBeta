namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollmentdatedeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "EnrollmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "EnrollmentDate", c => c.DateTime(nullable: false));
        }
    }
}
