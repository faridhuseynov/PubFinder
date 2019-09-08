namespace PubFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuItemPriceAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "Price", c => c.String());
            AlterColumn("dbo.MenuItems", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItems", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.MenuItems", "Price");
        }
    }
}
