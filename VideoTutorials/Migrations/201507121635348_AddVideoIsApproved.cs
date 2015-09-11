namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoIsApproved : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "isApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "isApproved");
        }
    }
}
