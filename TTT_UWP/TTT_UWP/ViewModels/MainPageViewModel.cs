using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTT_UWP.Classes;
using TTT_UWP.Domainclasses;
using TTT_UWP.Utility;

namespace TTT_UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Warehouse> warehouses;
        private Warehouse selectedWarehouse;

        public ICommand ChangeWarehouseCommand { get; set; }

        public MainPageViewModel()
        {
            LoadData();
            LoadCommands();
        }

        private void LoadData()
        {
            
        }

        private void LoadCommands()
        {
            ChangeWarehouseCommand = new CustomCommand(ChangeWarehouse, CanChangeWarehouse);
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

        public ObservableCollection<Warehouse> Magazijnen
        {
            get
            {
                return warehouses;
            }
            set
            {
                warehouses = value;
                RaisePropertyChanged("Magazijnen");
            }
        }

        public Warehouse SelectedMag
        {
            get
            {
                return selectedWarehouse;
            }
            set
            {
                selectedWarehouse = value;
                RaisePropertyChanged("SelectedMag");
            }
        }
    }
}
