using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderManagement.Entities
{
    public class AppleOrder
    {
        [Key]
        public Guid OrderID { get; set; }

        public DateTime CreateDate { get; set; }
        public string OrderSource { get; set; }

        public string AppleSpecification { get; set; }
        public string AppleType { get; set; }
        public string OtherRequirement { get; set; }
        public int Quantity { get; set; }
        public string CustomerInformation { get; set; }

        public DateTime DeliveryDate { get; set; }
        public string Delivery { get; set; }
        public string DeliveryNumber { get; set; }
        public string DeliveryRequirement { get; set; }

        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PayTime { get; set; }
        public bool IsTransfered { get; set; }
        public DateTime TransferedTime { get; set; }

        public string FeedBack { get; set; }

        public bool IsCanceled { get; set; }
        public string CanceledReason { get; set; }
    }
}
