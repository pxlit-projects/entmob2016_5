using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Utility;

namespace TTT_UWP.ViewModels
{
    public class AddProductPageViewModel : INotifyPropertyChanged
    {
        //Services
        private INavigationService navigationService;

        //Repositories
        private static IProductRepository productRepository = new ProductRepository();

        //Dataservices
        private static IProductDataService productDataService = new ProductDataService(productRepository);

        //Databinding
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddProductPageViewModel(INavigationService navigationService)
        {
            LoadCommands();
            this.navigationService = navigationService;
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(OnAddProduct, CanRedirect);
            CancelCommand = new CustomCommand(OnGoBack, CanRedirect);
        }

        private void OnAddProduct(object obj)
        {
            Product p = new Product { ProductID = 1, ProductName = "Sla", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 };
            productDataService.AddProduct(p);
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
            navigationService.GoBack();
        }

        private bool CanRedirect(object obj)
        {
            return true;
        }

        private void OnGoBack(object o)
        {
            navigationService.GoBack();
        }
    }
}
