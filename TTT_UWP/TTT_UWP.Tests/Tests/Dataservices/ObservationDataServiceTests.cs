using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Tests.Mocks;

namespace TTT_UWP.Tests.Dataservices
{
    [TestClass]
    public class ObservationDataServiceTests
    {
        private IObservationRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockObservationRepository();
        }

        [TestMethod]
        public void GetObservationById()
        {
            //Arrange
            var service = new ObservationDataService(repository);

            //Act
            var observation = service.GetObservationById(1);

            //Assert
            Assert.IsNotNull(observation);
        }

        [TestMethod]
        public void GetObservations()
        {
            //Arrange
            var service = new ObservationDataService(repository);

            //Act
            List<Observation> observations = service.GetObservations();

            //Assert
            Assert.IsNotNull(observations);
        }

        [TestMethod]
        public void GetObservationsByRegion()
        {
            //Arrange
            var service = new ObservationDataService(repository);

            //Act
            Region region = new Region
            {
                RegionID = 1,
                RegionName = "Groenten",
                WarehouseID = 1,
                SensorID = 1,
                Observations = null,
                Racks = null
            };

            List<Observation> observations = service.GetObservationsByRegion(region);

            //Assert
            Assert.IsNotNull(observations);
        }
    }
}
