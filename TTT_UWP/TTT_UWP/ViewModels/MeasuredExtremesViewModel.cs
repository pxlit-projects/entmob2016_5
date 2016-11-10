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
using TTT_UWP.Model.Hulpklassen;
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

        private static IRegionRepository regionRepository = new RegionRepository();
        private static IRegionDataService regionDataService = new RegionDataService(regionRepository);

        //Databinding 
        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        public ObservableCollection<MeasuredExtreme> measuredExtremes = new ObservableCollection<MeasuredExtreme>();
        private Warehouse selectedWarehouse = new Warehouse();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand GoBackCommand { get; set; }
        public ICommand RedirectCommand { get; set; }

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

        private void OnGoBack(object o)
        {
            navigationService.GoBack();
        }

        //Mag er geredirect worden (huidig altijd true)
        private bool CanRedirect(object o)
        {
            return true;
        }

        private void LoadCommands()
        {
            GoBackCommand = new CustomCommand(OnGoBack, CanRedirect);
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
        }

        private void LoadData()
        {
            //Ophalen waar ge-recorde temp/hum/pres groter is dan maximum van product of kleiner is dan minimum van product
            List<Observation> Observations = observationDataService.GetObservations();
            List<Region> Regions = regionDataService.GetRegions();

            foreach (Observation o in Observations)
            {
                double maxTemp = 0;
                foreach (Region r in Regions)
                {
                    if(r.RegionID == o.RegionID)
                    {
                        maxTemp = regionDataService.GetMaxTempPerRegion(r.RegionID);
                    }
                }

                if(o.Temperature > maxTemp)
                {
                    measuredExtremes.Add(new MeasuredExtreme { RegionID = o.RegionID, MaximumTemperature = maxTemp, Temperature =  o.Temperature,
                                                                Humidity = o.Humidity, Pressure = o.AirPressure});
                }
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
            }
        }

        public ObservableCollection<MeasuredExtreme> MeasuredExtremes
        {
            get
            {
                return measuredExtremes;
            }
            set
            {
                measuredExtremes = value;
            }
        }
    }
}
