using AppleOrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderManagement.Service
{
    public static class ExtensionAppleOrder
    {
        public static AppleOrderVO ToAppleOrderVO(this AppleOrder order)
        {
            AppleOrderVO vo = new AppleOrderVO();
            vo.Order = order;
            vo.IsChecked = false ;
            return vo;
        }

        public static List<AppleOrderVO> ToAppleOrderVOs(this List<AppleOrder> orders)
        {
            List<AppleOrderVO> vos = new List<AppleOrderVO>();
            orders.ForEach(order =>
            {
                var vo = order.ToAppleOrderVO();
                vos.Add(vo);
            });
            return vos;
        }
    }
}
