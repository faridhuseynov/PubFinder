namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommetAndCommentRatesUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentRates", "CommentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CommentRates", "CommentId");
            AddForeignKey("dbo.CommentRates", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentRates", "CommentId", "dbo.Comments");
            DropIndex("dbo.CommentRates", new[] { "CommentId" });
            DropColumn("dbo.CommentRates", "CommentId");
        }
    }
}
