using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleOrderManagement.Model;
using AutoMapper;
using AppleOrderManagement.Entities;

namespace AppleOrderManagement.Service
{
    class AppleOrderService : ICommonOperation
    {
        private AppleContext db;
        public AppleOrderService()
        {
            db = new Entities.AppleContext();
        }
        public int Add(AppleOrder order)
        {
            db.AppleOrders.Add(order);
            int result = db.SaveChanges();
            return result;
        }

        public List<AppleOrder> GetAll(bool isCanceled)
        {
            var orders = db.AppleOrders.Where(o=>o.IsCanceled==isCanceled).OrderByDescending(o=>o.CreateDate).ToList<AppleOrder>();
            return orders;
        }

        public List<AppleOrder> GetOrderBySearch(string searchString,bool isCanceled)
        {
            var orders = db.AppleOrders.Where(o => o.IsCanceled == isCanceled&&o.CustomerInformation.Contains(searchString)).OrderByDescending(o => o.CreateDate).ToList<AppleOrder>();
            return orders;
        }

        public int Update(AppleOrder order)
        {
            var currentOrder = db.AppleOrders.Find(order.OrderID);
            if (currentOrder != null)
            {
                db.Entry(currentOrder).CurrentValues.SetValues(order);
            }
            int result = db.SaveChanges();
            return result;
        }
    }
}
