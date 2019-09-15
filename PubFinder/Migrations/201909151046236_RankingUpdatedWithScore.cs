namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RankingUpdatedWithScore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rankings", "Score", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rankings", "Score");
        }
    }
}
