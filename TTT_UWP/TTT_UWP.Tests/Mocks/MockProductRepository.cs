using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Tests.Mocks
{
    public class MockProductRepository : IProductRepository
    {

        private List<Product> products;

        public MockProductRepository()
        {
            products = LoadMockProducts();
        }

        private List<Product> LoadMockProducts()
        {
            //mockdata
            return null;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product GetProduct()
        {
            return products.FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return products.Where(c => c.ProductID == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            Product productToUpdate = products.Where(c => c.ProductID == product.ProductID).FirstOrDefault();
            productToUpdate = product;
        }

        public int GetRegionIDOfProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public int GetMaxProductId()
        {
            throw new NotImplementedException();
        }
    }
}
