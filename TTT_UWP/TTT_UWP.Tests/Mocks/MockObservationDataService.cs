using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;

namespace TTT_UWP.Tests.Mocks
{
    public class MockObservationDataService : IObservationDataService
    {

        private IObservationRepository repository;

        public MockObservationDataService(IObservationRepository repository)
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
