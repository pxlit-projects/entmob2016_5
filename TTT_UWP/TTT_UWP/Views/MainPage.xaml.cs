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

namespace TTT_UWP
{
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<TemperatureMeasurement> Temps { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.Temps = new ObservableCollection<TemperatureMeasurement>
            {
                new TemperatureMeasurement { Date = "23/05/2016", Temp = 23},
                new TemperatureMeasurement { Date = "24/05/2016", Temp = 24},
                new TemperatureMeasurement { Date = "25/05/2016", Temp = 24},
                new TemperatureMeasurement { Date = "26/05/2016", Temp = 23},
                new TemperatureMeasurement { Date = "27/05/2016", Temp = 25},
                new TemperatureMeasurement { Date = "28/05/2016", Temp = 23},
            };
            DataContext = this;
        }
    }
}
