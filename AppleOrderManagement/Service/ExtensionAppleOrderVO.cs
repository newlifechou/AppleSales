using AppleOrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderManagement.Service
{
    public static class ExtensionAppleOrderVO
    {
        public static AppleOrder ToAppleOrder(this AppleOrderVO vo)
        {
            AppleOrder order = vo.Order;
            return order;
        }
        public static List<AppleOrder> ToAppleOrders(this List<AppleOrderVO> vos)
        {
            List<AppleOrder> orders = new List<AppleOrder>();
            vos.ForEach(vo =>
            {
                var order = vo.ToAppleOrder();
                orders.Add(order);
            });
            return orders;
        }

    }
}
