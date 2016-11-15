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
            if (products == null)
                LoadProducts();
            products.Remove(product);
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

        public int GetMaxProductId()
        {
            return products.OrderByDescending(c => c.ProductID).FirstOrDefault().ProductID;
        }

        public void UpdateProduct(Product product)
        {
            Product productToUpdate = products.Where(c => c.ProductID == product.ProductID).FirstOrDefault();
            productToUpdate = product;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public int GetRegionIDOfProduct(Product product)
        {
            IRackRepository repository = new RackRepository();

            return repository.GetRackById(product.RackID).RegionID;
        }

        public void LoadProducts()
        {
            products = new List<Product>()
            {
            new Product { ProductID = 1, ProductName = "Sla", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
            new Product { ProductID = 2, ProductName = "Meer sla", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 3, ProductName = "Wortel", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 4, ProductName = "Balsamico", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 5, ProductName = "Smartpony", RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };
        }

        public void Sync()
        {
            //sync met database
        }
    }
}
