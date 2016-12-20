namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        ISBN = c.String(),
                        State = c.String(),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "AccountID", "dbo.Account");
            DropIndex("dbo.Cart", new[] { "AccountID" });
            DropTable("dbo.Cart");
        }
    }
}
