using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Model
{
    public class Rack
    {
        public int RackID { get; set; }
        public int RegionID { get; set; }
        public Product[] Products { get; set; }
    }
}
