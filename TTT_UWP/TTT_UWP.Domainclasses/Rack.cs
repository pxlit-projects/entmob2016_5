using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Domainclasses
{
    public class Rack
    {
        public int RackID { get; set; }
        public int RegionID { get; set; }
        public Product[] Products { get; set; }
    }
}
