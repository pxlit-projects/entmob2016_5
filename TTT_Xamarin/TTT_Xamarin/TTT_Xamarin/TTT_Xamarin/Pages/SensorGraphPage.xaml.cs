using Xamarin.Forms;
using TTT_Xamarin.ViewModels;

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
