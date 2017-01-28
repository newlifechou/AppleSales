using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using AppleOrderManagement.Model;
using AppleOrderManagement.Service;
using AppleOrderManagement.Entities;

namespace AppleOrderManagement.ViewModel
{
    public class OrderEditVM : ViewModelBase
    {
        private bool IsAdd;
        public OrderEditVM(AppleOrder order)
        {
            #region InitialProperties
            //Add
            if (order == null)
            {
                IsAdd = true;
                CurrentOrder = new AppleOrder()
                {
                    OrderID = Guid.NewGuid(),
                    CreateDate = DateTime.Now,
                    OrderSource = "淘宝的订单",
                    AppleSpecification = "8008",
                    AppleType = "条纹红",
                    Quantity = 1,
                    OtherRequirement = "大小均匀",
                    CustomerInformation = "格式[姓名电话详细地址]",
                    Delivery = "中通",
                    DeliveryDate = DateTime.Now.AddDays(1),
                    DeliveryNumber = "",
                    DeliveryRequirement = "普通包装",
                    Price = 50,
                    IsPaid = true,
                    IsTransfered = false,
                    IsCanceled = false,
                    PayTime = DateTime.Now,
                    TransferedTime = DateTime.Now,
                    FeedBack = "",
                    CanceledReason = ""
                };
            }
            else
            {
                IsAdd = false;
                CurrentOrder = order;
            }




            #endregion

            #region InitialCommands
            SaveCommand = new RelayCommand(ActionSave);
            GiveupCommand = new RelayCommand(ActionGiveUp);
            #endregion
        }

        private void ActionSave()
        {
            //判断Add还是Edit
            var service = new AppleOrderService();
            if (IsAdd)
            {
                if (service.Add(CurrentOrder) == 0)
                {

                }
            }
            else
            {
                if (service.Update(CurrentOrder) == 0)
                {

                }
            }
            Messenger.Default.Send<AppleOrderVO>(null, TokenEnum.AllOrder);
            Messenger.Default.Send<AppleOrderVO>(null, TokenEnum.Refresh);
        }

        private void ActionGiveUp()
        {
            Messenger.Default.Send<AppleOrderVO>(null, TokenEnum.AllOrder);
        }


        #region Properties
        private AppleOrder currentOrder;
        public AppleOrder CurrentOrder
        {
            get { return currentOrder; }
            set { currentOrder = value; RaisePropertyChanged(nameof(CurrentOrder)); }
        }

        #endregion
        #region Command
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand GiveupCommand { get; set; }
        #endregion

    }
}
