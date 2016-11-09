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

namespace TTT_UWP.Tests.Tests.Dataservices
{
    [TestClass]
    public class RackDataServiceTests
    {
        private IRackRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockRackRepository();
        }

        [TestMethod]
        public void GetRackById()
        {
            //Arrange
            var service = new RackDataService(repository);

            //Act
            var rack = service.GetRackById(1);

            //Assert
            Assert.IsNotNull(rack);
        }

        [TestMethod]
        public void GetRacks()
        {
            //Arrange
            var service = new RackDataService(repository);

            //Act
            List<Rack> racks = service.GetRacks();

            //Assert
            Assert.IsNotNull(racks);
        }
    }
}