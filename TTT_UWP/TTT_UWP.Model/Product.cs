using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double MinimumTemperature { get; set; }
        public double MaximumTemperature { get; set; }
        public double MinimumHumidity { get; set; }
        public double MaximumHumidity { get; set; }
        public double MinimumAirPressure{ get; set; }
        public double MaximumAirPressure { get; set; }
        public int RackID { get; set; }
        public int WarehouseID { get; set; }
    }
}
