namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankingsDbAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rankings",
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
            DropForeignKey("dbo.Rankings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rankings", "PubId", "dbo.Pubs");
            DropIndex("dbo.Rankings", new[] { "PubId" });
            DropIndex("dbo.Rankings", new[] { "UserId" });
            DropTable("dbo.Rankings");
        }
    }
}
