using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.Extensions;
using TTT_Xamarin.Pages.Parts;

namespace TTT_Xamarin.ViewModels
{
    public class AboutPageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AboutSection> Sections { get; set; }
        public AboutPageViewModel()
        {
            Sections = AboutSections.getAll().ToObservableCollection();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sections"));
        }

    }
}
