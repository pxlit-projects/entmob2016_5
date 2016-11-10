using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Tests.Mocks
{
    public class MockRackRepository : IRackRepository
    {
        private List<Rack> racks;

        public MockRackRepository()
        {
            racks = LoadMockRacks();
        }

        private List<Rack> LoadMockRacks()
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

            Rack rack1 = new Rack { RackID = 4, RegionID = 2, Products = tshirts };
            Rack rack2 = new Rack { RackID = 5, RegionID = 2, Products = broeken };

            List<Rack> racks = new List<Rack>();
            racks.Add(rack1);
            racks.Add(rack2);

            return racks;
        }

        public void DeleteRack(Rack rack)
        {
            racks.Remove(rack);
        }

        public Rack GetRack()
        {
            return racks.FirstOrDefault();
        }

        public Rack GetRackById(int id)
        {
            return racks.Where(c => c.RackID == id).FirstOrDefault();
        }

        public List<Rack> GetRacks()
        {
            return racks;
        }

        public void UpdateRack(Rack rack)
        {
            Rack rackToUpdate = racks.Where(c => c.RackID == rack.RackID).FirstOrDefault();
            rackToUpdate = rack;
        }
    }
}
