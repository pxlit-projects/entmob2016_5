using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages
{
    public partial class DeviceScanPage : ContentPage
    {
        public DeviceScanPage()
        {
            InitializeComponent();
            BindingContext = new DeviceScanPageViewModel(Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "scan");
        }
    }
}
