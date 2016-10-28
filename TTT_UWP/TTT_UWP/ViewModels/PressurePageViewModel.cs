using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    class PressurePageViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Redirect
        private INavigationService navigationService;
        public ICommand RedirectCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        public IObservationRepository observationRepository;
        public ObservableCollection<Observation> observations = new ObservableCollection<Observation>();

        public PressurePageViewModel(INavigationService navigationService)
        {
            observationRepository = new ObservationRepository();
            AddDummyData();
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
            GoBackCommand = new CustomCommand(OnGoBack, CanRedirect);
            this.navigationService = navigationService;
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

        public void AddDummyData()
        {
            foreach (Observation item in observationRepository.GetObservations())
            {
                observations.Add(item);
            }
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

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
