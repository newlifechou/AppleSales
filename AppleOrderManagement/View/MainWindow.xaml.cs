using AppleOrderManagement.Model;
using AppleOrderManagement.ViewModel;
using GalaSoft.MvvmLight.Messaging;
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

namespace AppleOrderManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetMainContent(new OrderDisplayView());

            Messenger.Default.Register<AppleOrder>(this, TokenEnum.Add, ActionAdd);
            Messenger.Default.Register<AppleOrder>(this, TokenEnum.Edit, ActionAdd);

            Messenger.Default.Register<AppleOrderVO>(this, TokenEnum.AllOrder, ActionAllOrder);
            Messenger.Default.Register<string>(this, TokenEnum.Output, ActionOutput);
        }

        private void ActionOutput(string order)
        {
            var win = new OrderOutputView();
            var vm = new OrderOutputVM(order);
            win.DataContext = vm;
            SetMainContent(win);
        }

        private void ActionAllOrder(AppleOrderVO order)
        {
            SetMainContent(new OrderDisplayView());
        }

        private void ActionAdd(AppleOrder order)
        {
            var view = new OrderEditView();
            var viewModel = new OrderEditVM(order);
            view.DataContext = viewModel;
            SetMainContent(view);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            SetMainContent(new OrderDisplayView());
        }

        private void SetMainContent(UserControl control)
        {
            this.MainContent.Content = control;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            SetMainContent(new AdminLoginView());
        }
    }
}
