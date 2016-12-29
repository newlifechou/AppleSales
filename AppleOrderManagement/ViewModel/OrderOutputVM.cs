using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
namespace AppleOrderManagement.ViewModel
{
    public class OrderOutputVM : ViewModelBase
    {
        public OrderOutputVM(string content)
        {
            this.OutputContent = content;
        }

        private string outputContent;

        public string OutputContent
        {
            get { return outputContent; }
            set
            {
                outputContent = value;
                RaisePropertyChanged(nameof(outputContent));
            }
        }

    }
}
