using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderManagement.Entities
{
    public class AppleContext : DbContext
    {
        static AppleContext()
        {
            //Database.SetInitializer<AppleContext>(new AppleOrderIntializer());
        }
        public AppleContext() : base("name=AppleOrder")
        {

        }
        public DbSet<AppleOrder> AppleOrders { get; set; }

    }
}
