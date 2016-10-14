using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Domainclasses
{
    public class Observation
    {
        public int ObservationID { get; set; }
        public int RegionID { get; set; }
        public DateTime Timestamp { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double AirPressure { get; set; }
    }
}
