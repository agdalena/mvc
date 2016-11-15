namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Permission = c.String(),
                        Mail = c.String(),
                        Question = c.String(),
                        Answer = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Rent",
                c => new
                    {
                        RentID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        RentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RentID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .Index(t => t.AccountID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        ISBN = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.BookTag",
                c => new
                    {
                        BookTagID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookTagID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Book", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent", "BookID", "dbo.Book");
            DropForeignKey("dbo.Category", "CategoryID", "dbo.Book");
            DropForeignKey("dbo.BookTag", "TagID", "dbo.Tag");
            DropForeignKey("dbo.BookTag", "BookID", "dbo.Book");
            DropForeignKey("dbo.Rent", "AccountID", "dbo.Account");
            DropIndex("dbo.Category", new[] { "CategoryID" });
            DropIndex("dbo.BookTag", new[] { "TagID" });
            DropIndex("dbo.BookTag", new[] { "BookID" });
            DropIndex("dbo.Rent", new[] { "BookID" });
            DropIndex("dbo.Rent", new[] { "AccountID" });
            DropTable("dbo.Category");
            DropTable("dbo.Tag");
            DropTable("dbo.BookTag");
            DropTable("dbo.Book");
            DropTable("dbo.Rent");
            DropTable("dbo.Account");
        }
    }
}
