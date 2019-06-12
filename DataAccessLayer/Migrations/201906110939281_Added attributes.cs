namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedattributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workouts", "Workout_title", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "Workout_title", c => c.String(maxLength: 50));
        }
    }
}
