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
    public class WarehouseDataServiceTests
    {
        private IWarehouseRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new MockWarehouseRepository();
        }

        [TestMethod]
        public void GetWarehouseById()
        {
            //Arrange
            var service = new WarehouseDataService(repository);

            //Act
            var warehouse = service.GetWarehouseById(1);

            //Assert
            Assert.IsNotNull(warehouse);
        }

        [TestMethod]
        public void GetWarehouses()
        {
            //Arrange
            var service = new WarehouseDataService(repository);

            //Act
            List<Warehouse> warehouses = service.GetWarehouses();

            //Assert
            Assert.IsNotNull(warehouses);
        }

    }
}
