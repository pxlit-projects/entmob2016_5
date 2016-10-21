using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public class ProductDataService : IProductDataService
    {

        IProductRepository repository;

        public ProductDataService(IProductRepository repository)
        {
            this.repository = repository;
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
