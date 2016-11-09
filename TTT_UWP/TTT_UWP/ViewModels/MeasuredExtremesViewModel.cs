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
    public class MeasuredExtremesViewModel : INotifyPropertyChanged
    {
        //Services
        private INavigationService navigationService;

        //Repositories
        private static IObservationRepository observationRepository = new ObservationRepository();
        private static IObservationDataService observationDataService = new ObservationDataService(observationRepository);
        private static IProductRepository productRepository = new ProductRepository();
        private static IProductDataService productDataService = new ProductDataService(productRepository);

        //Databinding 
        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        private Warehouse selectedWarehouse = new Warehouse();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand GoBackCommand { get; set; }

        public MeasuredExtremesViewModel(INavigationService navigationService)
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

        private void LoadCommands()
        {
            GoBackCommand = new CustomCommand(OnRedirect, CanRedirect);
        }

        private void LoadData()
        {
            //Ophalen waar ge-recorde temp/hum/pres groter is dan maximum van product of kleiner is dan minimum van product
            
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
            }
        }
    }
}
