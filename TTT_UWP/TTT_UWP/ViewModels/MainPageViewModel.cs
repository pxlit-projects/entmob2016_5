using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Classes;

namespace TTT_UWP.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Magazijn> magazijnen;
        private Magazijn selectedMag;

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
