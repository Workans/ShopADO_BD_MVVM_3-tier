using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    class ManufacturerModelProxy
    {
        private static ManufacturerModelProxy proxy;
        public string ManufacturerName { get; set; }
        public static ManufacturerModelProxy Proxy => proxy ?? (proxy = new ManufacturerModelProxy());
    }
}
