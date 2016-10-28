using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT.Domainclasses
{
    public class Region
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public int WarehouseID { get; set; }
        public Rack[] Racks { get; set; }
        public Observation[] Observations { get; set; }
    }
}
