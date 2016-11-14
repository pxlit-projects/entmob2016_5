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
        private Product productToAdd;

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
            /*
            PropertyInfo productProperty = obj.GetType().GetProperty("Product");
            Product product = (Product)productProperty.GetValue(obj);

            product.ProductName = "foo";

            */
            var objType = this.GetType();
            List<PropertyInfo> properties = new List<PropertyInfo>();

            properties.AddRange(objType.GetProperties());

            foreach (PropertyInfo property in properties)
            {
                if (property.CanRead)
                {
                    if(property.Name == "ProductToAdd")
                    {
                        Object name = property.GetValue("txtName");
                    }
                }
            }

            /*
            
            Boolean somethingNull = false;
            Object o2 = obj;

            foreach (PropertyInfo pi in productToAdd.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(productToAdd);
                    if (string.IsNullOrEmpty(value))
                    {
                        somethingNull = true;
                        break;
                    }
                }
            }
            
            if (!somethingNull)
            {
                productDataService.AddProduct(productToAdd);
                Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
                navigationService.GoBack();
            }
            */
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
    }
}
