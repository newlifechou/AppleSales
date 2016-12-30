using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace AppleOrderManagement
{
    public static class CommonNavigation
    {
        public static void GoToNavigation()
        {
            Messenger.Default.Send<string>("Navigation", TokenEnum.Navigate);
        }
    }
}
