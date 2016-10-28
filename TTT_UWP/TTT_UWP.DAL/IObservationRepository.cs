using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Model;

namespace TTT.DAL
{
    public interface IObservationRepository
    {
        void DeleteObservation(Observation observation);
        Observation GetObservation();
        Observation GetObservationById(int id);
        List<Observation> GetObservations();
        List<Observation> GetObservationsByRegion(Region region);
        void UpdateObservation(Observation observation);
    }
}
    