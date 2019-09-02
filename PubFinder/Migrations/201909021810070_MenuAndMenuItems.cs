namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuAndMenuItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product = c.String(),
                        Quantity = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Rank = c.Double(nullable: false),
                        PubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pubs", t => t.PubId, cascadeDelete: true)
                .Index(t => t.PubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Menus", "PubId", "dbo.Pubs");
            DropIndex("dbo.Menus", new[] { "PubId" });
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            DropTable("dbo.Menus");
            DropTable("dbo.MenuItems");
        }
    }
}
