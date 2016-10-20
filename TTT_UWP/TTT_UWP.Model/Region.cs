using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Model
{
    public class Region
    {
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public int WarehouseID { get; set; }
        public int SensorID { get; set; }
        public Observation[] Observations { get; set; }
        public Rack[] Racks { get; set; }
    }
}
