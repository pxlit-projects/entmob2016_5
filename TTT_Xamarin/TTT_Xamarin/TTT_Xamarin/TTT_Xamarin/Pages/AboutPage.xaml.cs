using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutPageViewModel();
        }
    }
}
