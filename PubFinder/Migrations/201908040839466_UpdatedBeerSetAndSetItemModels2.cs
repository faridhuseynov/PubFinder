namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBeerSetAndSetItemModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SetItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Product = c.String(),
                        Quantity = c.Int(nullable: false),
                        BeerSetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeerSets", t => t.BeerSetId, cascadeDelete: true)
                .Index(t => t.BeerSetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SetItems", "BeerSetId", "dbo.BeerSets");
            DropIndex("dbo.SetItems", new[] { "BeerSetId" });
            DropTable("dbo.SetItems");
        }
    }
}
