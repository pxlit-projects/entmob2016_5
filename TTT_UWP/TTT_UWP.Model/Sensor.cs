using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Model
{
    public class Sensor
    {
        public int SensorID { get; set; }
        public string Mac { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
    }
}
