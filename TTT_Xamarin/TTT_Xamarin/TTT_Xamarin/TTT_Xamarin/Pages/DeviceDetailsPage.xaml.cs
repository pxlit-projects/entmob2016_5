using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

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