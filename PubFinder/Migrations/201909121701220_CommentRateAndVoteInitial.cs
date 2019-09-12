namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentRateAndVoteInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoteId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Votes", t => t.VoteId, cascadeDelete: true)
                .Index(t => t.VoteId);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Comments", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Weight", c => c.Int(nullable: false));
            DropForeignKey("dbo.CommentRates", "VoteId", "dbo.Votes");
            DropIndex("dbo.CommentRates", new[] { "VoteId" });
            DropTable("dbo.Votes");
            DropTable("dbo.CommentRates");
        }
    }
}
