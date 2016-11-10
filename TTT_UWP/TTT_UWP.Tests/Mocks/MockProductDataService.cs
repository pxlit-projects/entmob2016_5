using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;

namespace TTT_UWP.Tests.Mocks
{
    public class MockProductDataService : IProductDataService
    {

        private IProductRepository repository;

        public MockProductDataService(IProductRepository repository)
        {
            this.repository = repository;
        }

        public void AddProduct(Product product)
        {
            repository.AddProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            repository.DeleteProduct(product);
        }

        public Product GetProductById(int id)
        {
            return repository.GetProductById(id);
        }

        public List<Product> GetProducts()
        {
            return repository.GetProducts();
        }

        public List<Product> GetProductsByWarehouse(Warehouse warehouse)
        {
            return repository.GetProductsByWarehouse(warehouse);
        }

        public void UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
        }
    }
}
