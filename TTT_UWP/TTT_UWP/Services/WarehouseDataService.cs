using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public class WarehouseDataService : IWarehouseDataService
    {

        IWarehouseRepository repository;

        public WarehouseDataService(IWarehouseRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            repository.DeleteWarehouse(warehouse);
        }

        public Warehouse GetWarehouseById(int id)
        {
            return repository.GetWarehouseById(id);
        }

        public List<Warehouse> GetWarehouses()
        {
            return repository.GetWarehouses();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            repository.UpdateWarehouse(warehouse);
        }
    }
}
