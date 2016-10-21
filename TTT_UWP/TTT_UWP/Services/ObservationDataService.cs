using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.Services
{
    public class ObservationDataService : IObservationDataService
    {

        IObservationRepository repository;

        public ObservationDataService(IObservationRepository repository)
        {
            this.repository = repository;
        }

        public void DeleteObservation(Observation observation)
        {
            repository.DeleteObservation(observation);
        }

        public Observation GetObservationById(int id)
        {
            return repository.GetObservationById(id);
        }

        public List<Observation> GetObservations()
        {
            return repository.GetObservations();
        }

        public List<Observation> GetObservationsByRegion(Region region)
        {
            return repository.GetObservationsByRegion(region);
        }

        public void UpdateObservation(Observation observation)
        {
            repository.UpdateObservation(observation);
        }
    }
}
