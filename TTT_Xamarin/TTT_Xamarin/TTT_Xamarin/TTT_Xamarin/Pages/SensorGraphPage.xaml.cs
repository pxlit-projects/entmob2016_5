using ble = Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.Pages.Parts;
using Xamarin.Forms;
using TTT_Xamarin.ViewModels;
using System.Collections.ObjectModel;
using TTT_Xamarin.Models;

namespace TTT_Xamarin.Pages
{
    public partial class SensorGraphPage : ContentPage
    {
        public SensorGraphPage()
        {
            InitializeComponent();
            BindingContext = new SensorGraphPageViewModel();
        }
    }
}
