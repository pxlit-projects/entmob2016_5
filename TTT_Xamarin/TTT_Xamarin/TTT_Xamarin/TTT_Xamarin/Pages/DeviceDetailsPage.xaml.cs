using ble = Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.ViewModels;
using Xamarin.Forms;
using TTT_Xamarin.Pages.Parts;

namespace TTT_Xamarin.Pages
{
    public partial class DeviceDetailsPage : ContentPage
    {
        public DeviceDetailsPage()
        {
            InitializeComponent();
            BindingContext = new DeviceDetailsPageViewModel( Navigation);
        }
    }
}