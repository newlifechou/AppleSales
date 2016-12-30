using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;

namespace AppleOrderManagement.ViewModel
{
    public class NavigationVM : ViewModelBase
    {
        public NavigationVM()
        {
            GoToOrderDisplay = new RelayCommand(() => { Messenger.Default.Send<string>("OrderDisplay", TokenEnum.Navigate); });

        }

        #region Commands
        public RelayCommand GoToOrderDisplay { get; set; }
        #endregion
    }
}
