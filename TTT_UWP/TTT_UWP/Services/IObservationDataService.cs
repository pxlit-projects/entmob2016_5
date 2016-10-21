using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public interface IObservationDataService
    {
        void DeleteObservation(Observation observation);
        Observation GetObservationById(int id);
        List<Observation> GetObservations();
        List<Observation> GetObservationsByRegion(Region region);
        void UpdateObservation(Observation observation);
    }
}
