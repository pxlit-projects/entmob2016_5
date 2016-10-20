using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;

namespace TTT_UWP.DAL
{
    public class ObservationRepository : IObservationRepository
    {

        private static List<Observation> observations;

        public ObservationRepository()
        {

        }

        public void DeleteObservation(Observation observation)
        {
            observations.Remove(observation);
        }

        public Observation GetObservation()
        {
            if (observations == null)
                LoadObservations();
            return observations.FirstOrDefault();
        }

        public Observation GetObservationById(int id)
        {
            if (observations == null)
                LoadObservations();
            return observations.Where(c => c.ObservationID == id).FirstOrDefault();
        }

        public List<Observation> GetObservationsByRegion(Region region)
        {
            if (observations == null)
                LoadObservations();
            return observations.Where(c => c.RegionID == region.RegionID).ToList();
        }

        public List<Observation> GetObservations()
        {
            if (observations == null)
                LoadObservations();
            return observations;
        }

        public void UpdateObservation(Observation observation)
        {
            Observation observationToUpdate = observations.Where(c => c.ObservationID == observation.ObservationID).FirstOrDefault();
            observationToUpdate = observation;
        }

        public void LoadObservations()
        {

        }
    }
}
