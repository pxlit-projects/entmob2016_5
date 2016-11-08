using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Tests.Mocks;
using TTT_UWP.ViewModels;

namespace TTT_UWP.Tests.Viewmodels
{
    public class ProductsPageViewModelTests
    {
        private INavigationService navigationService;
        private IProductDataService productDataService;

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
            productDataService = new MockProductDataService(new MockProductRepository());
        }

        [TestMethod]
        public void LoadProducts()
        {
            //Arrange
            ObservableCollection<Product> products = null;
            var expectedProducts = productDataService.GetProducts();

            //Act
            var viewModel = new ProductPageViewModel(this.navigationService);
            products = viewModel.Products;

            //Assert
            CollectionAssert.AreEqual(expectedProducts, products);
        }
    }
}
