namespace AppleOrderManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AppleOrderManagement.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Model.AppleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AppleOrderManagement.Model.AppleContext";
        }

        protected override void Seed(AppleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //AppleOrder order = new AppleOrder();
            //order.OrderID = Guid.NewGuid();
            //order.CreateDate = DateTime.Now;
            //order.OrderSource = "来自鹏飞的订单";
            //order.AppleSpecification = "8008";
            //order.AppleType = "片红";
            //order.Quantity = 2;
            //order.CustomerInformation = "姚喜红18673992835湖南省绥宁县鹅公乡拱桥村五组";
            //order.Delivery = "中通";
            //order.DeliveryDate = DateTime.Now.AddDays(1);
            //order.DeliveryRequirement = "常规包装";
            //order.Price = 100;
            //order.FeedBack = "";
            //order.IsCanceled = false;
            //order.CanceledReason = "";
            //order.IsPaid = false;
            //order.IsTransfered = false;

            //context.AppleOrders.AddOrUpdate(a => a.OrderID, order);
        }
    }
}
