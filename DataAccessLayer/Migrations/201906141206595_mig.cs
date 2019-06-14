namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workouts", "Name", c => c.String());
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime());
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime());
            DropColumn("dbo.Workouts", "Name");
        }
    }
}
