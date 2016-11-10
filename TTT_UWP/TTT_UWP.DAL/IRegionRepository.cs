using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public interface IRegionRepository
    {
        void DeleteRegion(Region region);
        Region GetRegion();
        Region GetRegionById(int id);
        List<Region> GetRegions();
        List<Region> GetRegionsByWarehouse(Warehouse warehouse);
        void UpdateRegion(Region region);
        double GetMaxTempPerRegion(int regionId);
    }
}
