using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;

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
    }
}
