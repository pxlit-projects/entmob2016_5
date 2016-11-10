using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Model.Hulpklassen
{
    public class MeasuredExtreme
    {
        public int RegionID { get; set; }
        public double MaximumTemperature { get; set; }
        public double MaximumHumidity { get; set; }
        public double MaximumPressure { get; set; }
    }
}
