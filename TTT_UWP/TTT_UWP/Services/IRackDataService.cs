using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public interface IRackDataService
    {
        void DeleteRack(Rack rack);
        Rack GetRack();
        Rack GetRackById(int id);
        List<Rack> GetRacks();
        void UpdateRack(Rack rack);
    }
}
