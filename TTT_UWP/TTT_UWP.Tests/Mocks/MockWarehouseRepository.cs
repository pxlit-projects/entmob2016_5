using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Tests.Mocks
{
    public class MockWarehouseRepository : IWarehouseRepository
    {
        private List<Warehouse> warehouses;

        public MockWarehouseRepository()
        {
            warehouses = LoadMockWarehouses();
        }

        private List<Warehouse> LoadMockWarehouses()
        {
            //mockdata
            return null;
        }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            warehouses.Remove(warehouse);
        }

        public Warehouse GetWarehouse()
        {
            return warehouses.FirstOrDefault();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return warehouses.Where(c => c.WarehouseID == id).FirstOrDefault();
        }

        public List<Warehouse> GetWarehouses()
        {
            return warehouses;
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            Warehouse warehouseToUpdate = warehouses.Where(c => c.WarehouseID == warehouse.WarehouseID).FirstOrDefault();
            warehouseToUpdate = warehouse;
        }
    }
}
