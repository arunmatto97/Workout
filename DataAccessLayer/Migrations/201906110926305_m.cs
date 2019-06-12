namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entries",
                c => new
                    {
                        EntryNo = c.Int(nullable: false, identity: true),
                        Workout_id = c.Int(nullable: false),
                        start_date = c.DateTime(nullable: false),
                        start_time = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                        end_time = c.DateTime(nullable: false),
                        status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EntryNo)
                .ForeignKey("dbo.Workouts", t => t.Workout_id, cascadeDelete: true)
                .Index(t => t.Workout_id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Workout_title = c.String(maxLength: 50),
                        Workout_category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "Workout_id", "dbo.Workouts");
            DropIndex("dbo.Entries", new[] { "Workout_id" });
            DropTable("dbo.Workouts");
            DropTable("dbo.Entries");
        }
    }
}
