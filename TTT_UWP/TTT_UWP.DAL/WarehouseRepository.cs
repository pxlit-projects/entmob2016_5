using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public class WarehouseRepository : IWarehouseRepository
    {

        private List<Warehouse> warehouses;

        public WarehouseRepository()
        { }

        public void DeleteWarehouse(Warehouse warehouse)
        {
            warehouses.Remove(warehouse);
        }

        public Warehouse GetWarehouse()
        {
            if (warehouses == null)
                LoadWarehouses();
            return warehouses.FirstOrDefault();
        }

        public Warehouse GetWarehouseById(int id)
        {
            if (warehouses == null)
                LoadWarehouses();
            return warehouses.Where(c => c.WarehouseID == id).FirstOrDefault();
        }

        public List<Warehouse> GetWarehouses()
        {
            if (warehouses == null)
                LoadWarehouses();
            return warehouses;
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            Warehouse warehouseToUpdate = warehouses.Where(c => c.WarehouseID == warehouse.WarehouseID).FirstOrDefault();
            warehouseToUpdate = warehouse;
        }

        public void LoadWarehouses()
        {
            warehouses = new List<Warehouse> {
                new Warehouse { Regions = null, WarehouseID = 1, WarehouseName = "Iets Warehouse ofzo" },
                new Warehouse { Regions = null, WarehouseID = 2, WarehouseName = "Iets Warehousawdawde ofzo" },
                new Warehouse { Regions = null, WarehouseID = 3, WarehouseName = "Iets Waraasehouse ofzo" },
                new Warehouse { Regions = null, WarehouseID = 4, WarehouseName = "Iets Warehsssssouse ofzo" }
            };
        }

    }
}
