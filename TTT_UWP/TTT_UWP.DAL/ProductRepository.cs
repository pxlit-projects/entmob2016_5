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

        public void AddProduct(Product product)
        {
            //Add product to database
        }

        public void LoadProducts()
        {
            products = new List<Product>()
            {
            new Product { ProductID = 1, ProductName = "Sla", WarehouseID= 1, RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
            new Product { ProductID = 2, ProductName = "Meer sla", WarehouseID = 1, RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 3, ProductName = "Wortel", WarehouseID = 1, RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 4, ProductName = "Balsamico", WarehouseID = 1, RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
            new Product { ProductID = 5, ProductName = "Smartpony", WarehouseID = 1, RackID = 1, MaximumAirPressure = 10, MaximumHumidity = 10, MaximumTemperature = 10, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };
        }
    }
}
