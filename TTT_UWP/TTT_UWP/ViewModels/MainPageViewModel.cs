using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTT_UWP.Classes;
using TTT_UWP.Utility;

namespace TTT_UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Magazijn> magazijnen;
        private Magazijn selectedMag;

        public ICommand ChangeMagCommand { get; set; }

        public MainPageViewModel()
        {
            LoadData();
            LoadCommands();
        }

        private void LoadData()
        {
            //laad magazijnen
        }

        private void LoadCommands()
        {
            ChangeMagCommand = new CustomCommand(ChangeMag, CanChangeMag);
        }

        private void ChangeMag(object obj)
        {
            
        }

        private bool CanChangeMag(object obj)
        {
            if (SelectedMag != null)
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

        public ObservableCollection<Magazijn> Magazijnen
        {
            get
            {
                return magazijnen;
            }
            set
            {
                magazijnen = value;
                RaisePropertyChanged("Magazijnen");
            }
        }

        public Magazijn SelectedMag
        {
            get
            {
                return selectedMag;
            }
            set
            {
                selectedMag = value;
                RaisePropertyChanged("SelectedMag");
            }
        }
    }
}
