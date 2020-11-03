using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    public class GoodViewModelProxy
    {
        private static GoodViewModelProxy proxy;
        public string GoodName { get; set; }
        public decimal GoodCount { get; set; }
        public decimal GoodPrice { get; set; }
        public string GoodCategory { get; set; }
        public string GoodManufacturer { get; set; }
        public static GoodViewModelProxy Proxy => proxy ?? (proxy = new GoodViewModelProxy());
    }
}
