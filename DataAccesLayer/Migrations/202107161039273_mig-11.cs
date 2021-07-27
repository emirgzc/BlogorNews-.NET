namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "Category_CatId", "dbo.Categories");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "Writer_WriterId", "dbo.Writers");
            DropIndex("dbo.Blogs", new[] { "Category_CatId" });
            DropIndex("dbo.Blogs", new[] { "Writer_WriterId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropColumn("dbo.Blogs", "Category_CatId");
            DropColumn("dbo.Blogs", "Writer_WriterId");
            DropColumn("dbo.Comments", "BlogId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "BlogId", c => c.Int(nullable: false));
            AddColumn("dbo.Blogs", "Writer_WriterId", c => c.Int());
            AddColumn("dbo.Blogs", "Category_CatId", c => c.Int());
            CreateIndex("dbo.Comments", "BlogId");
            CreateIndex("dbo.Blogs", "Writer_WriterId");
            CreateIndex("dbo.Blogs", "Category_CatId");
            AddForeignKey("dbo.Blogs", "Writer_WriterId", "dbo.Writers", "WriterId");
            AddForeignKey("dbo.Comments", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "Category_CatId", "dbo.Categories", "CatId");
        }
    }
}
