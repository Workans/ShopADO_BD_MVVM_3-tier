using BLL.Services;
using DAL.Contexts;
using DAL.Repositories;
using ShopADO_BD_MVVM_3_tier.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopADO_BD_MVVM_3_tier.Infractructure
{
    class ViewModelLocator
    {
        public MainViewModel MainViewModel
        {
            get
            {
                var cotext = new ShopContext();
                var goodService = new GoodService(new GoodRepository(cotext), new UnitOfWork(cotext));
                var categoryService = new CategoryService(new CategoryRepository(cotext), new UnitOfWork(cotext));
                var manufacturerService = new ManufacturerService(new ManufacturerRepository(cotext), new UnitOfWork(cotext));
                return new MainViewModel(goodService, categoryService, manufacturerService);
            }
        }

    }
}
