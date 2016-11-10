using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TTT_UWP.Tests.Mocks;
using TTT_UWP.Services;
using System.Collections.ObjectModel;
using TTT_UWP.Model;
using TTT_UWP.ViewModels;

namespace TTT_UWP.Tests.Viewmodels
{
    [TestClass]
    public class MainPageViewModelTests
    {

        private INavigationService navigationService;
        private IWarehouseDataService warehouseDataService;
        private IObservationDataService observationDataService;

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
            warehouseDataService = new MockWarehouseDataService(new MockWarehouseRepository());
            observationDataService = new MockObservationDataService(new MockObservationRepository());
        }

        [TestMethod]
        public void LoadWarehouses()
        {
            //Arrange
            ObservableCollection<Warehouse> warehouses = null;
            var expectedWarehouses = warehouseDataService.GetWarehouses();

            //Act
            var viewModel = new MainPageViewModel(this.navigationService);
            warehouses = viewModel.Warehouses;

            //Assert
            CollectionAssert.AreEqual(expectedWarehouses, warehouses);
        }

        [TestMethod]
        public void LoadObservations()
        {
            //Arrange
            ObservableCollection<Observation> observations = null;
            var expectedObservations = observationDataService.GetObservations();

            //Act
            var viewModel = new MainPageViewModel(this.navigationService);
            observations = viewModel.Observations;

            //Assert
            CollectionAssert.AreEqual(expectedObservations, observations);


        }

    }
}
