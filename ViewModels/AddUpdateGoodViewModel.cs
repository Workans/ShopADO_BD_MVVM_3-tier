using BLL.Services;
using DAL.Contexts;
using DAL.Repositories;
using HT_5_Comlex_MVVM_DB;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    class AddUpdateGoodViewModel
    {
        // Proporties
        #region
        public string GoodName { get; set; }
        public decimal GoodCount { get; set; }
        public decimal GoodPrice { get; set; }
        public string GoodCategory { get; set; }
        public string GoodManufacturer { get; set; }

        public ICommand CloseCommand { get; set; }

        UnitOfWork unitOfWork;
        CategoryService categoryService;
        ManufacturerService manufacturerService;

        public List<string> Categories { get; set; } = new List<string>();
        public List<string> Manufacturers { get; set; } = new List<string>();
        #endregion

        public AddUpdateGoodViewModel()
        {
            var cotext = new ShopContext();

            categoryService = new CategoryService(new CategoryRepository(cotext), new UnitOfWork(cotext));
            manufacturerService = new ManufacturerService(new ManufacturerRepository(cotext), new UnitOfWork(cotext));

            InitCommands();

            Categories = categoryService.GetAll().Select(x => x.CategoryName.ToString()).ToList();
            Manufacturers = manufacturerService.GetAll().Select(x => x.ManufacturerName.ToString()).ToList();
        }

        private void InitCommands()
        {
            CloseCommand = new RelayCommand(x =>
              {
                  Window wnd = x as Window;

                  GoodViewModelProxy.Proxy.GoodName = GoodName;
                  GoodViewModelProxy.Proxy.GoodCount = GoodCount;
                  GoodViewModelProxy.Proxy.GoodPrice = GoodPrice;
                  GoodViewModelProxy.Proxy.GoodCategory = GoodCategory;
                  GoodViewModelProxy.Proxy.GoodManufacturer = GoodManufacturer;

                  wnd.Close();
              });
        }
    }
}
