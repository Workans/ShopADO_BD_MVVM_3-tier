using DAL.Repositories;
using HT_5_Comlex_MVVM_DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopADO_BD_MVVM_3_tier.ViewModels
{
    class AddUpdateCategoryViewModel
    {
        // Proporties
        #region
        public string CategoryName { get; set; }
        public ICommand CloseCommand { get; set; }
        #endregion

        public AddUpdateCategoryViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            CloseCommand = new RelayCommand(x =>
            {
                Window wnd = x as Window;
                CategoryViewModelProxy.Proxy.CategoryName = CategoryName;
                wnd.Close();
            });
        }
    }
}
