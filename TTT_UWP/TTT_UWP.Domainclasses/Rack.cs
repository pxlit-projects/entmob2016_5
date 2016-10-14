using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT_UWP.Domainclasses
{
    public class Rack
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RackID { get; set; }
        public int RegionID { get; set; }
        public Product[] Products { get; set; }
    }
}
