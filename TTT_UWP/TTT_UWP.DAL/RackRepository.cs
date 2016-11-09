using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public class RackRepository : IRackRepository
    {

        private List<Rack> racks;

        public void DeleteRack(Rack rack)
        {
            if (racks == null)
                LoadRacks();
            racks.Remove(rack);
        }

        public Rack GetRack()
        {
            if (racks == null)
                LoadRacks();
            return racks.FirstOrDefault();
        }

        public Rack GetRackById(int id)
        {
            if (racks == null)
                LoadRacks();
            return racks.Where(c => c.RackID == id).FirstOrDefault();
        }

        public List<Rack> GetRacks()
        {
            if (racks == null)
                LoadRacks();
            return racks;
        }

        public void UpdateRack(Rack rack)
        {
            Rack rackToUpdate = racks.Where(c => c.RackID == rack.RackID).FirstOrDefault();
            rackToUpdate = rack;
        }

        public void LoadRacks()
        {

        }
    }
}
