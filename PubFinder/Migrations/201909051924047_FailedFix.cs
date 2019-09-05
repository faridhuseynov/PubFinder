namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FailedFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IdentityRoles", "UserId", "dbo.Users");
            DropIndex("dbo.IdentityRoles", new[] { "UserId" });
            DropTable("dbo.IdentityRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.IdentityRoles", "UserId");
            AddForeignKey("dbo.IdentityRoles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
