using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages.Parts
{
    public partial class DeviceCell : ViewCell
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(DeviceCell), "Name");
        public DeviceCell()
        {
            InitializeComponent();
            BindingContext = new DeviceCellViewModel(NameProperty);
        }
    }
}
