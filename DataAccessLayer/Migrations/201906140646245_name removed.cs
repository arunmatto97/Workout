namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameremoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime());
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime());
            AlterColumn("dbo.Entries", "calories_burnt", c => c.Int());
            DropColumn("dbo.Workouts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Name", c => c.String());
            AlterColumn("dbo.Entries", "calories_burnt", c => c.Int(nullable: false));
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Entries", "end_date", c => c.DateTime(nullable: true));
        }
    }
}
