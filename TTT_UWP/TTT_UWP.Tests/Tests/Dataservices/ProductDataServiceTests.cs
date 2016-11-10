using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Tests.Mocks;

namespace TTT_UWP.Tests.Dataservices
{
    [TestClass]
    public class ProductDataServiceTests
    {
        private IProductRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockProductRepository();
        }

        [TestMethod]
        public void GetProductById()
        {
            //Arrange
            var service = new ProductDataService(repository);

            //Act
            var product = service.GetProductById(1);

            //Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetProducts()
        {
            //Arrange
            var service = new ProductDataService(repository);

            //Act
            List<Product> products = service.GetProducts();

            //Assert
            Assert.IsNotNull(products);
        }
    }
}
