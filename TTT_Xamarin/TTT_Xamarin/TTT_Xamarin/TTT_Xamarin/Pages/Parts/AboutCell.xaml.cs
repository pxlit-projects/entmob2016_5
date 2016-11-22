using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages.Parts
{
    public partial class AboutCell : ViewCell
    {
        public static readonly BindableProperty HeaderProperty =
            BindableProperty.Create("Header", typeof(string), typeof(AboutCell), "");
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(AboutCell), "");
        public AboutCell()
        {
            InitializeComponent();
            BindingContext = new AboutCellViewModel(HeaderProperty, TextProperty);
        }
    }
}
