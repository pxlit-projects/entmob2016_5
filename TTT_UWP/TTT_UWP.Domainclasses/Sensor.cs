using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Domainclasses;

namespace TTT.Domainclasses
{
    public class Sensor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SensorID { get; set; }
        public string Mac { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; }
    }
}
