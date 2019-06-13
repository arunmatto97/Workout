namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatusfieldinworkout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "status", c => c.String());
            DropColumn("dbo.Entries", "status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "status", c => c.String());
            DropColumn("dbo.Workouts", "status");
        }
    }
}
