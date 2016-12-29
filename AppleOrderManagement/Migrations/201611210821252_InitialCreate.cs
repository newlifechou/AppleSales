namespace AppleOrderManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppleOrders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        OrderSource = c.String(),
                        AppleSpecification = c.String(),
                        AppleType = c.String(),
                        OtherRequirement = c.String(),
                        Quantity = c.String(),
                        CustomerInformation = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        Delivery = c.String(),
                        DeliveryNumber = c.String(),
                        DeliveryRequirement = c.String(),
                        Price = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        PayTime = c.Boolean(nullable: false),
                        IsTransfered = c.Boolean(nullable: false),
                        TransferedTime = c.DateTime(nullable: false),
                        FeedBack = c.String(),
                        IsCanceled = c.Boolean(nullable: false),
                        CanceledReason = c.String(),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AppleOrders");
        }
    }
}
