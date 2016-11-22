using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TTT_Xamarin.Pages.Parts;
using Xamarin.Forms;

namespace TTT_Xamarin.ViewModels
{
    public class SensorDataCellViewModel : BindableObject
    {
        private BindableProperty dataProperty;
        private BindableProperty imageIdProperty;

        public string Data { get { return (string)GetValue(dataProperty); } }
        public string ImageId { get { return (string)GetValue(imageIdProperty); } }
        

        public SensorDataCellViewModel(BindableProperty dataProperty, BindableProperty imageIdProperty)
        {
            this.dataProperty = dataProperty;
            this.imageIdProperty = imageIdProperty;
        }
    }
}
