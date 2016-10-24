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
        private IWarehouseRepository warehouseRepository = new WarehouseRepository();

        //Databinding 
        private ObservableCollection<Warehouse> warehouses = new ObservableCollection<Warehouse>();
        private Warehouse selectedWarehouse = new Warehouse();
        public event PropertyChangedEventHandler PropertyChanged;

        //Commands
        public ICommand ButtonCommand { get; set; }
        public ICommand RedirectCommand { get; set; }
        
        public MainPageViewModel(INavigationService navigationService)
        {
            LoadData();
            LoadCommands();
            ButtonCommand = new CustomCommand(OnChangeWareHouse, CanRedirect);
            RedirectCommand = new CustomCommand(OnRedirect, CanRedirect);
            this.navigationService = navigationService;
        }

        //Command nest
        private void OnChangeWareHouse(object o)
        {
            //TODO: redirect naar warehouse db enzo
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
            foreach (Warehouse item in warehouseRepository.GetWarehouses())
            {
                warehouses.Add(item);
            }
        }

        private void LoadCommands()
        {
            //ChangeWarehouseCommand = new CustomCommand(ChangeWarehouse, CanChangeWarehouse);
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
