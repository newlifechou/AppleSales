using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleOrderManagement.Model
{
    /// <summary>
    /// 带有选择功能的复杂对象
    /// </summary>
    public class AppleOrderVO
    {
        public AppleOrder Order { get; set; }
        public bool IsChecked { get; set; }
    }
}
