using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using AppleOrderCreator.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace AppleOrderCreator.ViewModel
{
    public class MainWindowVM : ViewModelBase
    {
        public MainWindowVM()
        {
            InitialOrderSource();
            AppleOrder = new AppleOrder()
            {
                OrderSource = OrderSourceList[0],
                OrderContent = "9008规格1箱",
                Package = "常规包装",
                Delivery = "中通",
                Receiver = "",
                CreateTime = DateTime.Now,
                SendDate = DateTime.Now.Date.AddDays(1).ToString("yyyy-MM-dd") + "下午4点前发出去"
            };
            CreateCommand = new RelayCommand(CreateAction);
        }

        private void InitialOrderSource()
        {
            OrderSourceList = new ObservableCollection<string>();
            OrderSourceList.Add("淘宝的订单");
            OrderSourceList.Add("永生的订单");
            OrderSourceList.Add("新生的订单");
            OrderSourceList.Add("鹏飞的订单【不要贴店铺标签】");
            OrderSourceList.Add("其他的订单");
            OrderTypeList = new ObservableCollection<string>();
            OrderTypeList.Add("8008规格1箱");
            OrderTypeList.Add("8508规格1箱");
            OrderTypeList.Add("9008规格1箱");
            OrderTypeList.Add("9508规格1箱");
            OrderTypeList.Add("9颗礼盒规格1箱");
            OrderTypeList.Add("单个装规格1箱");
        }

        private void CreateAction()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("订单日期:");
            sb.AppendLine(AppleOrder.CreateTime.ToLongDateString());
            sb.Append("订单来源:");
            sb.AppendLine(AppleOrder.OrderSource);
            sb.Append("订单要求:");
            sb.AppendLine(AppleOrder.OrderContent);
            sb.Append("收件信息:");
            sb.AppendLine(AppleOrder.Receiver);
            sb.Append("快递要求:");
            sb.AppendLine(AppleOrder.Delivery);
            sb.Append("发货日期:");
            sb.AppendLine(AppleOrder.SendDate);
            OrderText = sb.ToString();

            string filename = DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
            string filepath = Path.Combine(Environment.CurrentDirectory, "OrderFile", filename);

            File.WriteAllText(filepath, OrderText);

        }

        #region 属性
        public ObservableCollection<string> OrderSourceList { get; set; }
        public ObservableCollection<string> OrderTypeList { get; set; }

        private AppleOrder appleOrder;
        public AppleOrder AppleOrder
        {
            get { return appleOrder; }
            set
            {
                appleOrder = value;
                RaisePropertyChanged(nameof(AppleOrder));
            }
        }

        private string orderText;

        public string OrderText
        {
            get { return orderText; }
            set
            {
                orderText = value;
                RaisePropertyChanged(nameof(OrderText));
            }
        }

        #endregion

        #region 命令
        public RelayCommand CreateCommand { get; private set; }
        #endregion

    }
}
