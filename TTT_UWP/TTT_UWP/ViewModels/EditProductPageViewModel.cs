using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class EditProductPageViewModel : INotifyPropertyChanged
    {
        //Services
        private INavigationService navigationService;

        //Repositories
        private static IProductRepository productRepository = new ProductRepository();

        //Dataservices
        private static IProductDataService productDataService = new ProductDataService(productRepository);

        //Databinding
        private Product selectedProduct = new Product();
        private string productName, productMaxTemperature, productMinTemperature, productMaxHumidity, productMinHumidity, productMaxAirPressure, productMinAirPressure, productId;
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public EditProductPageViewModel(INavigationService navigationService)
        {
            LoadCommands();
            
            //fout zit hier, komt niet eens in onproductreceived
            Messenger.Default.Register<Product>(this, (product) =>
            {
                OnProductReceived(product);
            });

            this.navigationService = navigationService;
        }

        private void OnProductReceived(Product product)
        {
            selectedProduct = product;
            ProductName = selectedProduct.ProductName;
            ProductId = Convert.ToString(selectedProduct.ProductID);

            ProductMaxAirPressure = Convert.ToString(selectedProduct.MaximumAirPressure);
            ProductMinAirPressure = Convert.ToString(selectedProduct.MinimumAirPressure);

            ProductMaxHumidity = Convert.ToString(selectedProduct.MaximumHumidity);
            ProductMinHumidity = Convert.ToString(selectedProduct.MinimumHumidity);

            ProductMaxTemperature = Convert.ToString(selectedProduct.MaximumTemperature);
            ProductMinTemperature = Convert.ToString(selectedProduct.MinimumTemperature);
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(OnEditProduct, CanRedirect);
            CancelCommand = new CustomCommand(OnGoBack, CanRedirect);
            GoBackCommand = new CustomCommand(OnGoBack, CanRedirect);
        }

        private void OnEditProduct(object obj)
        {
            productDataService.UpdateProduct((Product)obj);
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

        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
                selectedProduct.ProductName = value;
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
                selectedProduct.MaximumTemperature = Convert.ToInt32(value);
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
                selectedProduct.MinimumTemperature = Convert.ToInt32(value);
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
                selectedProduct.MaximumHumidity = Convert.ToInt32(value);
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
                selectedProduct.MinimumHumidity = Convert.ToInt32(value);
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
                selectedProduct.MaximumAirPressure = Convert.ToInt32(value);
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
                selectedProduct.MinimumAirPressure = Convert.ToInt32(value);
                RaisePropertyChanged("ProductMinAirPressure");
            }
        }

        public string ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
                selectedProduct.ProductID = Convert.ToInt32(value);
                RaisePropertyChanged("ProductId");
            }
        }
    }
}
