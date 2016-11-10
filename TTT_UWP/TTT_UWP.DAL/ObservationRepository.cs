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

        public void DeleteObservation(Observation observation)
        {
            if (observations == null)
                LoadObservations();

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
            observations = new List<Observation>
             {
                new Observation { ObservationID = 1, Temperature = 20.0, RegionID = 1, Humidity=5.0, AirPressure=11.9, Timestamp = DateTime.Now },
                new Observation { ObservationID = 2, Temperature = 21.0, RegionID = 1, Humidity=6.1, AirPressure=12.8, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 3, Temperature = 18.1, RegionID = 2, Humidity=7.2, AirPressure=13.7, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 4, Temperature = 24.2, RegionID = 2, Humidity=8.9, AirPressure=10.5, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 5, Temperature = 50.2, RegionID = 3, Humidity=10.1, AirPressure=12.4, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 6, Temperature = 53.6, RegionID = 3, Humidity=2.3, AirPressure=11.3, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 7, Temperature = 24.1, RegionID = 4, Humidity=2.3, AirPressure=10.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 8, Temperature = 21.2, RegionID = 4, Humidity=4.5, AirPressure=13.2, Timestamp = DateTime.Now  },
                new Observation { ObservationID = 9, Temperature = 24.2, RegionID = 5, Humidity=6.6, AirPressure=14.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 10, Temperature = 28.2, RegionID = 5, Humidity=2.3, AirPressure=15.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 11, Temperature = 24.8, RegionID = 6, Humidity=5.4, AirPressure=11.2, Timestamp = DateTime.Now   },
                new Observation { ObservationID = 12, Temperature = 15.9 , RegionID = 6, Humidity=5.8, AirPressure=10.2, Timestamp = DateTime.Now  }
             };
        }
    }
}
