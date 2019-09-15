namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankingModelAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pubs", "Rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pubs", "Rate");
        }
    }
}
