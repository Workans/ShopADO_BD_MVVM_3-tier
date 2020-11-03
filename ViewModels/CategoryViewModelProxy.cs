using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    class CategoryViewModelProxy
    {
        private static CategoryViewModelProxy proxy;
        public string CategoryName { get; set; }
        public static CategoryViewModelProxy Proxy => proxy ?? (proxy = new CategoryViewModelProxy());
    }
}
