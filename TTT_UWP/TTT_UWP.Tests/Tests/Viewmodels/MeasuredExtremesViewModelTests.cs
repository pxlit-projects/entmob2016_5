using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using TTT_UWP.Services;
using TTT_UWP.Tests.Mocks;
using System.Collections.ObjectModel;
using TTT_UWP.Model;
using TTT_UWP.ViewModels;

namespace TTT_UWP.Tests.Viewmodels
{
    [TestClass]
    public class MeasuredExtremesViewModelTests
    {
        private INavigationService navigationService;
        private IObservationDataService observationDataService;

        [TestInitialize]
        public void Init()
        {
            navigationService = new MockNavigationService();
            observationDataService = new MockObservationDataService(new MockObservationRepository());
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
