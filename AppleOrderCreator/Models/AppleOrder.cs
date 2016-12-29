using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderCreator.Models
{
    public class AppleOrder
    {

        public DateTime  CreateTime { get; set; }
        public string OrderSource { get; set; }
        public string OrderContent { get; set; }
        public string Package { get; set; }
        public string Receiver { get; set; }
        public string SendDate { get; set; }
        public string Delivery { get; set; }

    }
}
