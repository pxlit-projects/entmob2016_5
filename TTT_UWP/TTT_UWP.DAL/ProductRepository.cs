using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public class ProductRepository : IProductRepository
    {

        private static List<Product> products;

        public void DeleteProduct(Product product)
        {
            
        }

        public Product GetProduct()
        {
            if (products == null)
                LoadProducts();
            return products.FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            if (products == null)
                LoadProducts();
            return products.Where(c => c.ProductID == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            if (products == null)
                LoadProducts();
            return products;
        }

        public List<Product> GetProductsByWarehouse(Warehouse warehouse)
        {
            if (products == null)
                LoadProducts();
            return products.Where(c => c.WarehouseID == warehouse.WarehouseID).ToList();
        }

        public void UpdateProduct(Product product)
        {
            Product productToUpdate = products.Where(c => c.ProductID == product.ProductID).FirstOrDefault();
            productToUpdate = product;
        }

        public void LoadProducts()
        {
            //Load Products
        }
    }
}
