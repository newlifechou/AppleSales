using AppleOrderManagement.Service;
using AppleOrderManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppleOrderManagement.View
{
    /// <summary>
    /// OrderAddView.xaml 的交互逻辑
    /// </summary>
    public partial class OrderEditView : UserControl
    {
        public OrderEditView()
        {
            InitializeComponent();
            Initial();
        }

        private void Initial()
        {
            cboOrderSource.ItemsSource = CommonService.GetData("OrderSource.txt");
            cboAppleSpecification.ItemsSource = CommonService.GetData("AppleSpecification.txt");
            cboAppleTpye.ItemsSource = CommonService.GetData("AppleType.txt");
        }
    }
}
