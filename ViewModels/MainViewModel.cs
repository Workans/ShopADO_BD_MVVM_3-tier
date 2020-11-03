using HT_5_Comlex_MVVM_DB;
using ShopADO_BD_MVVM_3_tier.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BLL.DTO;
using BLL.Services;
using DAL.Repositories;
using DAL.Contexts;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    class MainViewModel
    {
        #region
        public GoodDTO SelectedGood { get; set; }
        public CategoryDTO SelectedCategory { get; set; }
        public ManufacturerDTO SelectedManufactirer { get; set; }

        public ObservableCollection<GoodDTO> Goods { get; set; }
        public ObservableCollection<CategoryDTO> Categories { get; set; }
        public ObservableCollection<ManufacturerDTO> Manufacturers { get; set; }

        GoodService goodService;
        CategoryService categoryService;
        ManufacturerService manufacturerService;

        public ICommand RemoveGoodCommand { get; private set; }
        public ICommand AddUpdateGoodCommand { get; set; }
        public ICommand RemoveCategoryCommand { get; private set; }
        public ICommand AddUpdateCategoryCommand { get; set; }
        public ICommand RemoveManufacturerCommand { get; private set; }
        public ICommand AddUpdateManufacturerCommand { get; set; }
        #endregion
        public MainViewModel(GoodService goodService, CategoryService categoryService, ManufacturerService manufacturerService)
        {
            this.goodService = goodService;
            this.categoryService = categoryService;
            this.manufacturerService = manufacturerService;

            Categories = new ObservableCollection<CategoryDTO>(categoryService.GetAll());
            Goods = new ObservableCollection<GoodDTO>(goodService.GetAll());
            Manufacturers = new ObservableCollection<ManufacturerDTO>(manufacturerService.GetAll());

            InitCommands();
        }

        private void InitCommands()
        {
            RemoveGoodCommand = new RelayCommand(x =>
            {
                goodService.Remove(SelectedGood);
                Goods.Remove(SelectedGood);                
            });

            RemoveCategoryCommand = new RelayCommand(x =>
            {
                categoryService.Remove(SelectedCategory);
                Categories.Remove(SelectedCategory);
            });

            RemoveManufacturerCommand = new RelayCommand(x =>
            {
                manufacturerService.Remove(SelectedManufactirer);
                Manufacturers.Remove(SelectedManufactirer);
            });

            AddUpdateGoodCommand = new RelayCommand(x =>
              {
                  AddUpdateGood dlg = new AddUpdateGood();
                  dlg.ShowDialog();
                  var good = new GoodDTO
                  {
                      GoodName = GoodViewModelProxy.Proxy.GoodName,
                      GoodCount = GoodViewModelProxy.Proxy.GoodCount,
                      Price = GoodViewModelProxy.Proxy.GoodPrice,
                      CategoryId = categoryService.GetAll().FirstOrDefault(y => y.CategoryName == GoodViewModelProxy.Proxy.GoodCategory).CategoryId,
                      ManufacturerId = manufacturerService.GetAll().FirstOrDefault(y => y.ManufacturerName == GoodViewModelProxy.Proxy.GoodManufacturer).ManufacturerId
                  };
                  var result = goodService.CreateOrUpdate(good);
                  Goods.Add(result);                  
              });

            AddUpdateCategoryCommand = new RelayCommand(x =>
              {
                  AddUpdateCategoryView dlg = new AddUpdateCategoryView();
                  dlg.ShowDialog();
                  var category = new CategoryDTO
                  {
                      CategoryName = CategoryViewModelProxy.Proxy.CategoryName
                  };
                  var result = categoryService.CreateOrUpdate(category);
                  Categories.Add(result);
              });

            AddUpdateManufacturerCommand = new RelayCommand(x =>
            {
                AddUpdateManufactorerView dlg = new AddUpdateManufactorerView();
                dlg.ShowDialog();
                var manufactorer = new ManufacturerDTO
                {
                    ManufacturerName = ManufacturerModelProxy.Proxy.ManufacturerName
                };
                var result = manufacturerService.CreateOrUpdate(manufactorer);
                Manufacturers.Add(result);
            });
        }
    }
}
