using AppleOrderManagement.Model;
using AppleOrderManagement.View;
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
using System.ComponentModel;

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

            SetContent(new NavigationView());
            Messenger.Default.Register<string>(this, TokenEnum.Navigate, viewName =>
            {
                switch (viewName)
                {
                    case "OrderDisplay":
                        SetContent(new OrderDisplayView());
                        break;
                    case "Navigation":
                        SetContent(new NavigationView());
                        break;
                    default:
                        SetContent(new NavigationView());
                        break;
                };
            });
        }
        private void SetContent(UserControl view)
        {
            if (view!=null)
            {
                this.main.Content = view;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Messenger.Default.Unregister(this);
            base.OnClosing(e);
        }
    }
}
