namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latestjun14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime());
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime());
            DropColumn("dbo.Workouts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Name", c => c.String());
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime(nullable: false));
        }
    }
}
