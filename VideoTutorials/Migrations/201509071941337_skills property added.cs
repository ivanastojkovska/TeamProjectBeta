namespace VideoTutorials.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class skillspropertyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Skills", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Skills");
        }
    }
}
