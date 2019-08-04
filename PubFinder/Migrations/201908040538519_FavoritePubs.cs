namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FavoritePubs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FavoritePubs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pubs", t => t.PubId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FavoritePubs", "UserId", "dbo.Users");
            DropForeignKey("dbo.FavoritePubs", "PubId", "dbo.Pubs");
            DropIndex("dbo.FavoritePubs", new[] { "PubId" });
            DropIndex("dbo.FavoritePubs", new[] { "UserId" });
            DropTable("dbo.FavoritePubs");
        }
    }
}
