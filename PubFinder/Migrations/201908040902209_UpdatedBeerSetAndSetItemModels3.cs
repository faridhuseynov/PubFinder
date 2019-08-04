namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBeerSetAndSetItemModels3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerSets", "PubId", c => c.Int(nullable: false));
            CreateIndex("dbo.BeerSets", "PubId");
            AddForeignKey("dbo.BeerSets", "PubId", "dbo.Pubs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BeerSets", "PubId", "dbo.Pubs");
            DropIndex("dbo.BeerSets", new[] { "PubId" });
            DropColumn("dbo.BeerSets", "PubId");
        }
    }
}
