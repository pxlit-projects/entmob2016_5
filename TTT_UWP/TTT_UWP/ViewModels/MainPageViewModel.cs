using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using TTT_UWP.DAL;
using TTT_UWP.Model;
using TTT_UWP.Utility;

namespace TTT_UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private ObservableCollection<Warehouse> warehouses = new ObservableCollection<Warehouse>();
        private Warehouse selectedWarehouse = new Warehouse();
        private IWarehouseRepository warehouseRepository = new WarehouseRepository();

        public ICommand ButtonCommand { get; set; }
        public ICommand RedirectCommand { get; set; }

        public MainPageViewModel()
        {
            LoadData();
            LoadCommands();
            ButtonCommand = new CustomCommand(OnDelete, CanDelete);
        } 

        //Command nest
        private void OnDelete(object o)
        {
            Debug.WriteLine("Warehouse: " + selectedWarehouse.WarehouseName);
        }

        private bool CanDelete(object o)
        {
            return true;
        }

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
