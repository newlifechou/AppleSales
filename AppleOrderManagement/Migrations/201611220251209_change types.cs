namespace AppleOrderManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppleOrders", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.AppleOrders", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppleOrders", "Price", c => c.String());
            AlterColumn("dbo.AppleOrders", "Quantity", c => c.String());
        }
    }
}
