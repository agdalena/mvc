namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "CategoryID", "dbo.Book");
            DropIndex("dbo.Category", new[] { "CategoryID" });
            DropPrimaryKey("dbo.Category");
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        BookCategoryID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookCategoryID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.CategoryID);
            
            AlterColumn("dbo.Category", "CategoryID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Category", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCategory", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.BookCategory", "BookID", "dbo.Book");
            DropIndex("dbo.BookCategory", new[] { "CategoryID" });
            DropIndex("dbo.BookCategory", new[] { "BookID" });
            DropPrimaryKey("dbo.Category");
            AlterColumn("dbo.Category", "CategoryID", c => c.Int(nullable: false));
            DropTable("dbo.BookCategory");
            AddPrimaryKey("dbo.Category", "CategoryID");
            CreateIndex("dbo.Category", "CategoryID");
            AddForeignKey("dbo.Category", "CategoryID", "dbo.Book", "BookID");
        }
    }
}
