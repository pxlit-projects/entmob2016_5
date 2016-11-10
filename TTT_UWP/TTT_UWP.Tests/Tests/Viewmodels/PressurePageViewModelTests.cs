using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Tests.Mocks;
using TTT_UWP.ViewModels;

namespace TTT_UWP.Tests.Viewmodels
{
    public class PressurePageViewModelTests
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
            var viewModel = new PressurePageViewModel(this.navigationService);
            observations = viewModel.Observations;

            //Assert
            CollectionAssert.AreEqual(expectedObservations, observations);
        }
    }
}
