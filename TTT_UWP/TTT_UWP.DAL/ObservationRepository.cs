using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Model;

namespace TTT.DAL
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
            observations = new List<Observation>
             {
                new Observation { ObservationID = 1, Temperature = 20, RegionID = 1, Humidity=5, AirPressure=10 },
                new Observation { ObservationID = 2, Temperature = 21, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 3, Temperature = 18, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 4, Temperature = 24, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 5, Temperature = 20, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 6, Temperature = 23, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 7, Temperature = 24, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 8, Temperature = 21, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 9, Temperature = 24, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 10, Temperature = 28, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 11, Temperature = 24, RegionID = 1, Humidity=5, AirPressure=10  },
                new Observation { ObservationID = 12, Temperature = 15 , RegionID = 1, Humidity=5, AirPressure=10 }
             };
        }
    }
}
