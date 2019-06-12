namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "status", c => c.String());
            AlterColumn("dbo.Workouts", "Name", c => c.String());
            AlterColumn("dbo.Workouts", "Workout_title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Workouts", "Workout_category", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Workout_category", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "Workout_title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Workouts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Entries", "status", c => c.String(nullable: false));
        }
    }
}
