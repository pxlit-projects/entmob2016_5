using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Model
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string WarehouseName { get; set; }
        public List<Region> Regions { get; set; }
    }
}
