namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnsaddedinentries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "entry_status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "entry_status");
        }
    }
}
