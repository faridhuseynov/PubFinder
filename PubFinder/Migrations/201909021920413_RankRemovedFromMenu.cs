namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankRemovedFromMenu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Menus", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Price", c => c.Int(nullable: false));
        }
    }
}
