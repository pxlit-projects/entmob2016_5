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
            double lowestMaxTemp = 0;

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

            Observation[] observations = new Observation[]
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

            Product[] groenten = new Product[]
            {
                new Product { ProductID = 1, ProductName = "Sla", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 2, ProductName = "Tomaat", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 3, ProductName = "Komkommer", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 4, ProductName = "Wortel", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 5, ProductName = "Boon", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            Product[] fruit = new Product[]
            {
                new Product { ProductID = 6, ProductName = "Banaan", WarehouseID = 1, RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 7, ProductName = "Appel", WarehouseID = 1, RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 8, ProductName = "Peer", WarehouseID = 1, RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 9, ProductName = "Mango", WarehouseID = 1, RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 10, ProductName = "Druif", WarehouseID = 1, RackID = 2, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            Product[] drank = new Product[]
            {
                new Product { ProductID = 11, ProductName = "Melk", WarehouseID = 1, RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 12, ProductName = "Chocolademelk", WarehouseID = 1, RackID = 1, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 13, ProductName = "Cola", WarehouseID = 1, RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 14, ProductName = "Fanta", WarehouseID = 1, RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 15, ProductName = "Sprite", WarehouseID = 1, RackID = 3, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            Rack[] racksRegion1 = new Rack[]
            {
                new Rack { RackID = 1, RegionID = 1, Products = groenten},
                new Rack { RackID = 2, RegionID = 1, Products = fruit},
                new Rack { RackID = 3, RegionID = 1, Products = drank},
            };

            Product[] tshirts = new Product[]
            {
                new Product { ProductID = 16, ProductName = "T-Shirt S", WarehouseID = 1, RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 17, ProductName = "T-Shirt M", WarehouseID = 1, RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 18, ProductName = "T-Shirt L", WarehouseID = 1, RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 19, ProductName = "T-Shirt XL", WarehouseID = 1, RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 20, ProductName = "T-Shirt XXL", WarehouseID = 1, RackID = 4, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            Product[] broeken = new Product[]
            {
                new Product { ProductID = 21, ProductName = "Broek S", WarehouseID = 1, RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10},
                new Product { ProductID = 22, ProductName = "Broek M", WarehouseID = 1, RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 23, ProductName = "Broek L", WarehouseID = 1, RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 24, ProductName = "Broek XL", WarehouseID = 1, RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 },
                new Product { ProductID = 25, ProductName = "Broek XXL", WarehouseID = 1, RackID = 5, MaximumAirPressure = 20, MaximumHumidity = 20, MaximumTemperature = 20, MinimumAirPressure = 10, MinimumHumidity = 10, MinimumTemperature = 10 }
            };

            Rack[] racksRegion2 = new Rack[]
            {
                new Rack { RackID = 4, RegionID = 2, Products = tshirts},
                new Rack { RackID = 5, RegionID = 2, Products = broeken},
            };

            regions = new List<Region>
            {
                new Region { RegionID = 1, SensorID = 1, WarehouseID = 1, Observations = observations, Racks = racksRegion1, RegionName = "Eten en drinken"},
                new Region { RegionID = 2, SensorID = 2, WarehouseID = 1, Observations = observations, Racks = racksRegion2, RegionName = "Kleren" }
            };
        }
    }
}
