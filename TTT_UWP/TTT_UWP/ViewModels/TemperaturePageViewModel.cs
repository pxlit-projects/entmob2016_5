using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Utility;

namespace TTT_UWP.ViewModels
{
    public class TemperaturePageViewModel : INotifyPropertyChanged
    {
        //Vars
        private Region selectedRegion;

        //Services
        private INavigationService navigationService;

        //Dataservices
        private static IObservationRepository observationRepository = new ObservationRepository();
        private static IObservationDataService observationDataService = new ObservationDataService(observationRepository);

        private static IRegionRepository regionRepository = new RegionRepository();
        private static IRegionDataService regionDataservice = new RegionDataService(regionRepository);

        //Databinding
        public ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        public ObservableCollection<Region> regions = new ObservableCollection<Region>();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand RedirectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ICommand RegionSelectCommand { get; set; }

        public TemperaturePageViewModel(INavigationService navigationService)
        {
            LoadData();
            LoadCommands();
            this.navigationService = navigationService;
        }

        private void OnRegionSelect(object o)
        {
            observations.Clear();
            foreach (Observation item in observationDataService.GetObservations())
            {
                if (item.RegionID == selectedRegion.RegionID)
                {
                    observations.Add(item);
                }
            }
        }

        private void OnRedirect(object o)
        {
            navigationService.Navigate(TypeHelper.GetTypeByString(o.ToString(), this.GetType().GetTypeInfo().Assembly));
        }

        private void OnGoBack(object o)
        {
            navigationService.GoBack();
        }

        //Mag er geredirect worden (huidig altijd true)
        private bool CanRedirect(object o)
        {
            return true;
        }

        public void LoadData()
        {
            foreach (Observation item in observationDataService.GetObservations())
            {
                if(item.RegionID == 1)
                {
                    observations.Add(item);
                }
            }
            foreach (Region region in regionDataservice.GetRegions())
            {
                regions.Add(region);
            }
        }

        private void LoadCommands()
        {
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
            GoBackCommand = new CustomCommand(OnGoBack, CanRedirect);
            RegionSelectCommand = new CustomCommand(OnRegionSelect, CanRedirect);
        }

        public ObservableCollection<Observation> Observations
        {
            get
            {
                return observations;
            }
            set
            {
                observations = value;
                RaisePropertyChanged("Observations");
            }
        }

        public ObservableCollection<Region> Regions
        {
            get
            {
                return regions;
            }
            set
            {
                regions = value;
                RaisePropertyChanged("Regions");
            }
        }

        public Region SelectedRegion
        {
            get
            {
                if(selectedRegion == null)
                {
                    selectedRegion = regionDataservice.GetRegionById(1);
                }
                return selectedRegion;
            }
            set
            {
                selectedRegion = value;
                RaisePropertyChanged("SelectedRegion");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
