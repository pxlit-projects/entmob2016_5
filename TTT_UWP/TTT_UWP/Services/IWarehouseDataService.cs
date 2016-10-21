using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public interface IWarehouseDataService
    {
        void DeleteWarehouse(Warehouse warehouse);
        Warehouse GetWarehouseById(int id);
        List<Warehouse> GetWarehouses();
        void UpdateWarehouse(Warehouse warehouse);
    }
}
