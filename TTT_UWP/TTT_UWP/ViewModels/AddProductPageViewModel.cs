using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
        private Product productToAdd = new Product();

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }
                
        private string productName;
        private string productMaxTemperature, productMinTemperature, productMaxHumidity, productMinHumidity, productMaxAirPressure, productMinAirPressure;

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
            productToAdd.ProductID = productDataService.GetMaxProductId() + 1;
            productDataService.AddProduct(productToAdd);
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

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Product ProductToAdd
        {
            get
            {
                return productToAdd;
            }
            set
            {
                productToAdd = value;
                RaisePropertyChanged("ProductToAdd");
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
                productToAdd.ProductName = value;
                RaisePropertyChanged("ProductName");
            }
        }

        public string ProductMaxTemperature
        {
            get
            {
                return productMaxTemperature;
            }

            set
            {
                productMaxTemperature = value;
                productToAdd.MaximumTemperature = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMaxTemperature");
            }
        }

        public string ProductMinTemperature
        {
            get
            {
                return productMinTemperature;
            }

            set
            {
                productMinTemperature = value;
                productToAdd.MinimumTemperature = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMinTemperature");
            }
        }

        public string ProductMaxHumidity
        {
            get
            {
                return productMaxHumidity;
            }

            set
            {
                productMaxHumidity = value;
                productToAdd.MaximumHumidity = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMaxHumidity");
            }
        }

        public string ProductMinHumidity
        {
            get
            {
                return productMinHumidity;
            }

            set
            {
                productMinHumidity = value;
                productToAdd.MinimumHumidity = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMinHumidity");
            }
        }

        public string ProductMaxAirPressure
        {
            get
            {
                return productMaxAirPressure;
            }

            set
            {
                productMaxAirPressure = value;
                productToAdd.MaximumAirPressure = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMaxAirPressure");
            }
        }

        public string ProductMinAirPressure
        {
            get
            {
                return productMinAirPressure;
            }

            set
            {
                productMinAirPressure = value;
                productToAdd.MinimumAirPressure = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMinAirPressure");
            }
        }
    }
}
