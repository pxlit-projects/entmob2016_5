using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages.Parts
{
    public partial class SensorDataCell : ViewCell
    {
        public static readonly BindableProperty DataProperty =
            BindableProperty.Create("Data", typeof(string), typeof(SensorDataCell), "");
        public static readonly BindableProperty ImageIdProperty =
            BindableProperty.Create("ImageId", typeof(string), typeof(SensorDataCell), "icon.png");

        public SensorDataCell()
        {
            InitializeComponent();
            BindingContext = new SensorDataCellViewModel(DataProperty,ImageIdProperty);
        }
    }
}
