namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcaloriescolumninworkoutandentries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "calories_burnt", c => c.Int(nullable: false));
            AddColumn("dbo.Workouts", "calories_perminute", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workouts", "calories_perminute");
            DropColumn("dbo.Entries", "calories_burnt");
        }
    }
}
