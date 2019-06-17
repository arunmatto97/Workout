namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Entries", "end_time", c => c.DateTime());
        }
    }
}
