namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "CatId", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "WriterId", "dbo.Writers");
            DropIndex("dbo.Blogs", new[] { "CatId" });
            DropIndex("dbo.Blogs", new[] { "WriterId" });
            RenameColumn(table: "dbo.Blogs", name: "CatId", newName: "Category_CatId");
            RenameColumn(table: "dbo.Blogs", name: "WriterId", newName: "Writer_WriterId");
            AlterColumn("dbo.Blogs", "Category_CatId", c => c.Int());
            AlterColumn("dbo.Blogs", "Writer_WriterId", c => c.Int());
            CreateIndex("dbo.Blogs", "Category_CatId");
            CreateIndex("dbo.Blogs", "Writer_WriterId");
            AddForeignKey("dbo.Blogs", "Category_CatId", "dbo.Categories", "CatId");
            AddForeignKey("dbo.Blogs", "Writer_WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "Writer_WriterId", "dbo.Writers");
            DropForeignKey("dbo.Blogs", "Category_CatId", "dbo.Categories");
            DropIndex("dbo.Blogs", new[] { "Writer_WriterId" });
            DropIndex("dbo.Blogs", new[] { "Category_CatId" });
            AlterColumn("dbo.Blogs", "Writer_WriterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Blogs", "Category_CatId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Blogs", name: "Writer_WriterId", newName: "WriterId");
            RenameColumn(table: "dbo.Blogs", name: "Category_CatId", newName: "CatId");
            CreateIndex("dbo.Blogs", "WriterId");
            CreateIndex("dbo.Blogs", "CatId");
            AddForeignKey("dbo.Blogs", "WriterId", "dbo.Writers", "WriterId", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "CatId", "dbo.Categories", "CatId", cascadeDelete: true);
        }
    }
}
