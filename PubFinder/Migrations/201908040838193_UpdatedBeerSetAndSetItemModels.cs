namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBeerSetAndSetItemModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BeerSets", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BeerSets", "Name");
        }
    }
}
