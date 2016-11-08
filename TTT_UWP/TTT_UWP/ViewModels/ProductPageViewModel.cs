using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class ProductPageViewModel : INotifyPropertyChanged
    {
        //Services
        private INavigationService navigationService;

        //Repositories
        private IProductRepository productRepository = new ProductRepository();

        //Databinding 
        private ObservableCollection<Product> products = new ObservableCollection<Product>();
        private Product selectedProduct = new Product();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand DeleteCommand { get; set; }
        public ICommand RedirectCommand { get; set; }

        public ProductPageViewModel(INavigationService navigationService)
        {
            LoadData();
            LoadCommands();

            this.navigationService = navigationService;

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);
        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
        }

        private void LoadData()
        {
            foreach (Product product in productRepository.GetProducts())
            {
                products.Add(product);
            }
        }

        private void LoadCommands()
        {
            DeleteCommand = new CustomCommand(OnDeleteCommand, CanRedirect);
            RedirectCommand = new CustomCommand(OnRedirectCommand, CanRedirect);
        }

        //Commands
        private void OnChangeProduct(object o)
        {
            //TODO: redirect naar warehouse db enzo
            Debug.WriteLine("Product: " + selectedProduct.ProductName);
        }

        /*
         * Redirect via navigationService, meegegeven parameters zitten in object o
         * Parameter is een string die zegt naar welke pagina verwezen moet worden,
         * string wordt via typehelper service omgezet naar Type.
        */
        private void OnRedirectCommand(object o)
        {/*
            if (o.ToString().Equals("EditProductPage"))
                Messenger.Default.Send<Product>(selectedProduct);
                */
            navigationService.Navigate(TypeHelper.GetTypeByString(o.ToString(), this.GetType().GetTypeInfo().Assembly));
        }

        private void OnProductReceived(Product product)
        {
            SelectedProduct = product;
        }

        //Mag er geredirect worden (huidig altijd true)
        private bool CanRedirect(object o)
        {
            return true;
        }

        private void OnDeleteCommand(object obj)
        {
            productRepository.DeleteProduct(selectedProduct);
        }

        private bool CanEditOrDeleteProduct(object obj)
        {
            if (selectedProduct != null)
                return true;
            return false;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                RaisePropertyChanged("Products");
            }
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
    }
}
