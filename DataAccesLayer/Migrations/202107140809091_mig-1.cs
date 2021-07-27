namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "Link");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Link", c => c.String(maxLength: 50));
        }
    }
}
