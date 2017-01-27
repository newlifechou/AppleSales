using AppleOrderManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppleOrderManagement.Entities;

namespace AppleOrderManagement.Service
{
    public interface ICommonOperation
    {
        List<AppleOrder> GetAll(bool isCanceled);
        List<AppleOrder> GetOrderBySearch(string searchString,bool isCanceled);
        int Add(AppleOrder order);
        int Update(AppleOrder order);
    }
}
