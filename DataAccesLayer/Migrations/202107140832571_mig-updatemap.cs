namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migupdatemap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "Map", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Map", c => c.String(maxLength: 150));
        }
    }
}
