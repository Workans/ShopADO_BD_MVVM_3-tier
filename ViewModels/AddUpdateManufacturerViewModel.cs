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
    class AddUpdateManufacturerViewModel
    {
        // Proporties
        #region
        public string ManufacturerName { get; set; }
        public ICommand CloseCommand { get; set; }
        #endregion

        public AddUpdateManufacturerViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            CloseCommand = new RelayCommand(x =>
            {
                Window wnd = x as Window;
                ManufacturerModelProxy.Proxy.ManufacturerName = ManufacturerName;
                wnd.Close();
            });
        }
    }
}
