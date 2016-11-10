using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public class RegionRepository : IRegionRepository
    {

        private static List<Region> regions;

        public void DeleteRegion(Region region)
        {
            if (regions == null)
                LoadRegions();
            regions.Remove(region);
        }

        public Region GetRegion()
        {
            if (regions == null)
                LoadRegions();
            return regions.FirstOrDefault();
        }

        public Region GetRegionById(int id)
        {
            if (regions == null)
                LoadRegions();
            return regions.Where(c => c.RegionID == id).FirstOrDefault();
        }

        public List<Region> GetRegions()
        {
            if (regions == null)
                LoadRegions();
            return regions;
        }

        public List<Region> GetRegionsByWarehouse(Warehouse warehouse)
        {
            if (regions == null)
                LoadRegions();
            return regions.Where(c => c.WarehouseID == warehouse.WarehouseID).ToList();
        }

        public void UpdateRegion(Region region)
        {
            Region regionToUpdate = regions.Where(c => c.RegionID == region.RegionID).FirstOrDefault();
            regionToUpdate = region;
        }

        public double GetMaxTempPerRegion(int regionId)
        {
            IProductRepository repository = new ProductRepository();

            List<Product> products = repository.GetProducts();
            double lowestMaxTemp = 99;

            foreach (Product p in products)
            {
                if (repository.GetRegionIDOfProduct(p) == regionId)
                {
                    if (p.MinimumTemperature < lowestMaxTemp)
                    {
                        lowestMaxTemp = p.MinimumTemperature;
                    }
                }
            }

            return lowestMaxTemp;
        }

        public void LoadRegions()
        {

           List<Observation> observations = new List<Observation>()
             {
                new Observation { ObservationID = 1, Temperature = 20.0, RegionID = 1, Humidity=5.0, AirPressure=11.9, Timestamp = DateTime.Now },
                new Observation { ObservationID = 2, Temperature = 21.0, RegionID = 1, Humidity=6.1, AirPressure=12.8, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 3, Temperature = 18.1, RegionID = 2, Humidity=7.2, AirPressure=13.7, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 4, Temperature = 24.2, RegionID = 2, Humidity=8.9, AirPressure=10.5, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 5, Temperature = 20.2, RegionID = 3, Humidity=10.1, AirPressure=12.4, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 6, Temperature = 23.6, RegionID = 3, Humidity=2.3, AirPressure=11.3, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 7, Temperature = 24.1, RegionID = 4, Humidity=2.3, AirPressure=10.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 8, Temperature = 21.2, RegionID = 4, Humidity=4.5, AirPressure=13.2, Timestamp = DateTime.Now  },
                new Observation { ObservationID = 9, Temperature = 24.2, RegionID = 5, Humidity=6.6, AirPressure=14.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 10, Temperature = 28.2, RegionID = 5, Humidity=2.3, AirPressure=15.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 11, Temperature = 24.8, RegionID = 6, Humidity=5.4, AirPressure=11.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 12, Temperature = 15.9 , RegionID = 6, Humidity=5.8, AirPressure=10.2, Timestamp = DateTime.Now  }
             };

            List<Product> groenten = new List<Product>()
            {
                new Product { ProductID = 1, ProductName = "Sla", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 2, ProductName = "Tomaat", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 3, ProductName = "Komkommer", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 4, ProductName = "Wortel", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 5, ProductName = "Boon", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            List<Product> fruit = new List<Product>
            {
                new Product { ProductID = 6, ProductName = "Banaan", RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 7, ProductName = "Appel", RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 8, ProductName = "Peer", RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 9, ProductName = "Mango", RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 10, ProductName = "Druif", RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            List<Product> drank = new List<Product>()
            {
                new Product { ProductID = 11, ProductName = "Melk", RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 12, ProductName = "Chocolademelk", RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 13, ProductName = "Cola", RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 14, ProductName = "Fanta", RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 15, ProductName = "Sprite", RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            List<Rack> racksRegion1 = new List<Rack>()
            {
                new Rack { RackID = 1, RegionID = 1, Products = groenten},
                new Rack { RackID = 2, RegionID = 1, Products = fruit},
                new Rack { RackID = 3, RegionID = 1, Products = drank},
            };

            List<Product> tshirts = new List<Product>()
            {
                new Product { ProductID = 16, ProductName = "T-Shirt S", RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 17, ProductName = "T-Shirt M", RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 18, ProductName = "T-Shirt L", RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 19, ProductName = "T-Shirt XL", RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 20, ProductName = "T-Shirt XXL", RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            List<Product> broeken = new List<Product>()
            {
                new Product { ProductID = 21, ProductName = "Broek S", RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 22, ProductName = "Broek M", RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 23, ProductName = "Broek L", RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 24, ProductName = "Broek XL", RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 25, ProductName = "Broek XXL", RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            List<Rack> racksRegion2 = new List<Rack>()
            {
                new Rack { RackID = 4, RegionID = 2, Products = tshirts},
                new Rack { RackID = 5, RegionID = 2, Products = broeken},
            };

            regions = new List<Region>
            {
                new Region { RegionID = 1, SensorID = 1, WarehouseID = 1, Observations = observations, Racks = racksRegion1, RegionName = "Eten en drinken"},
                new Region { RegionID = 2, SensorID = 2, WarehouseID = 1, Observations = observations, Racks = racksRegion2, RegionName = "Kleren" },
            new Region { RegionID = 3, SensorID = 3, WarehouseID = 1, Observations = observations, Racks = racksRegion2, RegionName = "Kleren" },
            new Region { RegionID = 4, SensorID = 4, WarehouseID = 1, Observations = observations, Racks = racksRegion1, RegionName = "Kleren" }
            };
        }
    }
}
