namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CatId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "WriterId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogs", "CatId");
            CreateIndex("dbo.Blogs", "WriterId");
            CreateIndex("dbo.Comments", "BlogId");
            AddForeignKey("dbo.Blogs", "CatId", "dbo.Categories", "CatId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "CatId", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "WriterId" });
            DropIndex("dbo.Blogs", new[] { "CatId" });
            DropColumn("dbo.Comments", "BlogId");
            DropColumn("dbo.Blogs", "WriterId");
            DropColumn("dbo.Blogs", "CatId");
        }
    }
}
