using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using AppleOrderManagement.Model;
using AppleOrderManagement.Service;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppleOrderManagement.ViewModel
{
    public class OrderDisplayVM : ViewModelBase
    {
        private AppleOrderService service;
        public OrderDisplayVM()
        {
            Messenger.Default.Register<AppleOrderVO>(this, TokenEnum.Refresh, ActionRefresh);

            #region InitialProperties
            StateInformation = "运行正常";
            SearchString = "";
            IsDeleted = false;
            #endregion

            #region IntialCommand
            AddCommand = new RelayCommand(ActionAdd);
            EditCommand = new RelayCommand<AppleOrderVO>(ActionEdit);
            DeleteCommand = new RelayCommand<AppleOrderVO>(ActionDelete);
            SearchCommand = new RelayCommand(ActionSearch);
            GetAllCommand = new RelayCommand(ActionGetAll);
            OutputCommand = new RelayCommand(ActionOutPut);

            Navigation = new RelayCommand(() => { CommonNavigation.GoToNavigation(); });
            #endregion

            service = new AppleOrderService();
            GetAllOrders();
        }

        private void ActionOutPut()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in AppleOrders)
            {
                if (item.IsChecked)
                {
                    var order = item.Order;
                    sb.AppendLine(order.CreateDate.ToString("yyyy-MM-dd"));
                    sb.AppendLine(order.CustomerInformation);
                    sb.Append(order.AppleSpecification);
                    sb.Append(" ");
                    sb.Append(order.AppleType);
                    sb.Append(" ");
                    sb.Append(order.Quantity.ToString());
                    sb.AppendLine("箱,快递");
                    sb.Append(order.Delivery);
                    sb.Append(",发货日期");
                    sb.AppendLine(order.DeliveryDate.ToString("yyyy-MM-dd"));
                    sb.AppendLine();
                }
            }
            Messenger.Default.Send<string>(sb.ToString(), TokenEnum.Output);
        }

        private void ActionRefresh(AppleOrderVO obj)
        {
            GetAllOrders();
        }

        private void ActionDelete(AppleOrderVO orderComplex)
        {
            AppleOrder order = orderComplex.Order;
            if (MessageBox.Show("确定作废?", "作废", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                order.IsCanceled = true;
                service.Update(order);
                GetAllOrders();
            }
        }

        private void ActionEdit(AppleOrderVO orderVO)
        {
            //发送切换编辑视图的消息
            var order = orderVO.Order;
            Messenger.Default.Send<AppleOrder>(order, TokenEnum.Edit);
        }

        private void ActionSearch()
        {
            var orders = service.GetOrderBySearch(SearchString, IsDeleted);
            AppleOrders = new ObservableCollection<AppleOrderVO>(orders.ToAppleOrderVOs());
            StateInformation = $"检索结果共{AppleOrders.Count}个";
        }

        private void ActionGetAll()
        {
            GetAllOrders();
            SearchString = "";
        }

        private void GetAllOrders()
        {
            var orders = service.GetAll(IsDeleted);

            AppleOrders = new ObservableCollection<AppleOrderVO>(orders.ToAppleOrderVOs());
            StateInformation = $"检索结果共{AppleOrders.Count}个";
        }



        private void ActionAdd()
        {
            //发送切换编辑视图的消息
            Messenger.Default.Send<AppleOrder>(null, TokenEnum.Add);
        }

        #region Properties
        private ObservableCollection<AppleOrderVO> appleOrders;
        public ObservableCollection<AppleOrderVO> AppleOrders
        {
            get { return appleOrders; }
            set { appleOrders = value; RaisePropertyChanged(nameof(AppleOrders)); }
        }

        private string stateInformation;
        public string StateInformation
        {
            get { return stateInformation; }
            set { stateInformation = value; RaisePropertyChanged(nameof(StateInformation)); }
        }


        private string searchString;

        public string SearchString
        {
            get { return searchString; }
            set { searchString = value; RaisePropertyChanged(nameof(SearchString)); }
        }


        private bool isDeleted;

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; RaisePropertyChanged(nameof(IsDeleted)); }
        }

        #endregion

        #region Commands
        public RelayCommand Navigation { get; private set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand<AppleOrderVO> EditCommand { get; set; }
        public RelayCommand<AppleOrderVO> DeleteCommand { get; set; }
        public RelayCommand GetAllCommand { get; set; }
        public RelayCommand OutputCommand { get; set; }
        #endregion

        public override void Cleanup()
        {
            Messenger.Default.Unregister(this);
            base.Cleanup();
        }

    }
}
