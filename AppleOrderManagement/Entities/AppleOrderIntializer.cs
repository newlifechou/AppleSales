using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace AppleOrderManagement.Entities
{
    public class AppleOrderIntializer : DropCreateDatabaseIfModelChanges<AppleContext>
    {
        private AppleContext context;
        public AppleOrderIntializer()
        {
            context = new AppleContext();
        }
        protected override void Seed(AppleContext context)
        {
            AppleOrder order = new AppleOrder();
            order.OrderID = Guid.NewGuid();
            order.CreateDate = DateTime.Now;
            order.OrderSource = "来自鹏飞的订单";
            order.AppleSpecification = "8008";
            order.AppleType = "片红";
            order.Quantity = 2;
            order.CustomerInformation = "姚喜红18673992835湖南省绥宁县鹅公乡拱桥村五组";
            order.Delivery = "中通";
            order.DeliveryDate = DateTime.Now.AddDays(1);
            order.DeliveryRequirement = "常规包装";
            order.Price = 100;
            order.FeedBack = "";
            order.IsCanceled = false;
            order.CanceledReason = "";
            order.IsPaid = false;
            order.IsTransfered = false;



            context.AppleOrders.Add(order);
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
