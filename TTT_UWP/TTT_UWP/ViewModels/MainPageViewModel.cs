using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Services;
using TTT_UWP.Utility;
using TTT_UWP.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TTT_UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        //Services
        private INavigationService navigationService;

        //Repositories
        private static IObservationRepository observationRepository = new ObservationRepository();

        //Dataservices
        private static IObservationDataService observationDataService = new ObservationDataService(observationRepository);

        //Databinding 
        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand ButtonCommand { get; set; }
        public ICommand RedirectCommand { get; set; }
        
        public MainPageViewModel(INavigationService navigationService)
        {
            LoadData();
            LoadCommands();
            this.navigationService = navigationService;
        }

        /*
         * Redirect via navigationService, meegegeven parameters zitten in object o
         * Parameter is een string die zegt naar welke pagina verwezen moet worden,
         * string wordt via typehelper service omgezet naar Type.
        */
        private void OnRedirect(object o)
        {            
            navigationService.Navigate(TypeHelper.GetTypeByString(o.ToString(), this.GetType().GetTypeInfo().Assembly));                    
        }

        //Mag er geredirect worden (huidig altijd true)
        private bool CanRedirect(object o)
        {
            return true;
        }

        //Laad de lijst van warehouses in (observable collection)
        private void LoadData()
        {
            foreach (Observation item in observationRepository.GetObservations())
            {
                observations.Add(item);
            }
        }

        private void LoadCommands()
        {
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    }
}
