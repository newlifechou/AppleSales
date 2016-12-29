namespace AppleOrderManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppleOrders", "PayTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppleOrders", "PayTime", c => c.Boolean(nullable: false));
        }
    }
}
