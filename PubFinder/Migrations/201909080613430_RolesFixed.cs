namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropIndex("dbo.Roles", new[] { "UserId" });
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            DropColumn("dbo.Roles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropColumn("dbo.Users", "RoleId");
            CreateIndex("dbo.Roles", "UserId");
            AddForeignKey("dbo.Roles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
