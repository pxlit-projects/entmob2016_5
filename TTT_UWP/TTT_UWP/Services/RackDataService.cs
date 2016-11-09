using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public class RackDataService : IRackDataService
    {

        IRackRepository repository;

        public RackDataService(IRackRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteRack(Rack rack)
        {
            throw new NotImplementedException();
        }

        public Rack GetRack()
        {
            return repository.GetRack();
        }

        public Rack GetRackById(int id)
        {
            return repository.GetRackById(id);
        }

        public List<Rack> GetRacks()
        {
            return repository.GetRacks();
        }

        public void UpdateRack(Rack rack)
        {
            throw new NotImplementedException();
        }
    }
}

