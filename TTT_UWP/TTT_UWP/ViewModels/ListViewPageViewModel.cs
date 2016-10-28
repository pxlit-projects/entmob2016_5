using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.DAL;
using TTT_UWP.Model;

namespace TTT_UWP.ViewModels
{
    public class ListViewPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IObservationRepository observationRepository;
        public ObservableCollection<Observation> observations = new ObservableCollection<Observation>();

        public ListViewPageViewModel()
        {
            observationRepository = new ObservationRepository();
            AddDummyData();
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
