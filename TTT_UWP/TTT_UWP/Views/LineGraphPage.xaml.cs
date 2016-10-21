using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TTT_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TemperatureWindow : Page
    {
        //public ObservableCollection<TemperatureMeasurement> Temps { get; set; }
        
        /*
        public void ChangeLayout()
        {

            this.Temps = new ObservableCollection<TemperatureMeasurement>
            {
                new TemperatureMeasurement { Date = "1", Temp = 23},
                new TemperatureMeasurement { Date = "2", Temp = 24},
                new TemperatureMeasurement { Date = "3", Temp = 24},
                new TemperatureMeasurement { Date = "4", Temp = 23},
                new TemperatureMeasurement { Date = "5", Temp = 25},
                new TemperatureMeasurement { Date = "6", Temp = 23},
            };
            DataContext = this;

            listView.ItemsSource = Temps;
        }*/
        public TemperatureWindow()
        {
            this.InitializeComponent();
        }
    }
}
