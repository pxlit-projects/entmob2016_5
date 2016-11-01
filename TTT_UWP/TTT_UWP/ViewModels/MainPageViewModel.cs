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

<<<<<<< HEAD
        //Dataservices
        private static IWarehouseRepository warehouseRepository = new WarehouseRepository();
        private static IWarehouseDataService warehouseDataService = new WarehouseDataService(warehouseRepository);
=======
        //Repositories
        private IWarehouseRepository warehouseRepository = new WarehouseRepository();
        private IObservationRepository observationRepository = new ObservationRepository();
>>>>>>> a1e875726b86269b60f5d1f631590d4fa4bbdcb0

        //Databinding 
        private ObservableCollection<Warehouse> warehouses = new ObservableCollection<Warehouse>();
        private ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
        private Warehouse selectedWarehouse = new Warehouse();
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

        //Commands
        private void OnChangeWareHouse(object o)
        {
            //TODO: databinding op grafieken en dropdownlist wijzigen 
            Debug.WriteLine("Warehouse: " + selectedWarehouse.WarehouseName);
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
            foreach (Warehouse item in warehouseDataService.GetWarehouses())
            {
                warehouses.Add(item);
            }
            foreach (Observation item in observationRepository.GetObservations())
            {
                observations.Add(item);
            }
        }

        private void LoadCommands()
        {
            ButtonCommand = new CustomCommand(OnChangeWareHouse, CanRedirect);
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
        }

        private void ChangeWarehouse(object obj)
        {

        }

        private bool CanChangeWarehouse(object obj)
        {
            if (selectedWarehouse != null)
                return true;
            return false;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Warehouse> Warehouses
        {
            get
            {
                return warehouses;
            }
            set
            {
                warehouses = value;
                RaisePropertyChanged("Warehouses");
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
                RaisePropertyChanged("Wbservations");
            }
        }

        public Warehouse SelectedWarehouse
        {
            get
            {
                return selectedWarehouse;
            }
            set
            {
                selectedWarehouse = value;
                RaisePropertyChanged("SelectedWarehouse");
            }
        }


    }
}
