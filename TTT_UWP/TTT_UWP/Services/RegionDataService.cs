using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public class RegionDataService : IRegionDataService
    {

        IRegionDataService repository;

        public RegionDataService(IRegionDataService repository)
        {
            this.repository = repository;
        }

        public void DeleteRegion(Region region)
        {
            repository.DeleteRegion(region);
        }

        public Region GetRegion()
        {
            return repository.GetRegion();
        }

        public Region GetRegionById(int id)
        {
            return repository.GetRegionById(id);
        }

        public List<Region> GetRegions()
        {
            return repository.GetRegions();
        }

        public List<Region> GetRegionsByWarehouse(Warehouse warehouse)
        {
            return repository.GetRegionsByWarehouse(warehouse);
        }

        public void UpdateRegion(Region region)
        {
            repository.UpdateRegion(region);
        }
    }
}
