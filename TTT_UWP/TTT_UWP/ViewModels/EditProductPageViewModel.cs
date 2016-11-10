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
        private Product selectedProduct;
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand EditCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EditProductPageViewModel(INavigationService navigationService)
        {
            LoadCommands();

            Messenger.Default.Register<Product>(this, OnProductReceived);

            this.navigationService = navigationService;
        }

        private void OnProductReceived(Product product)
        {
            selectedProduct = product;
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(OnEditProduct, CanRedirect);
            CancelCommand = new CustomCommand(OnGoBack, CanRedirect);
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
    }
}
