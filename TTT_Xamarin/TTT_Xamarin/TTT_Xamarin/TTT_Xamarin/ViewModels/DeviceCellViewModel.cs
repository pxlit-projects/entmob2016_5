using System.ComponentModel;
using System.Windows.Input;
using TTT_Xamarin.Pages.Parts;
using Xamarin.Forms;

namespace TTT_Xamarin.ViewModels
{
    public class DeviceCellViewModel : BindableObject, INotifyPropertyChanged
    {
        private BindableProperty nameProperty;

        public string Name { get { return (string)GetValue(nameProperty); } }
        
        public DeviceCellViewModel(BindableProperty nameProperty)
        {
            this.nameProperty = nameProperty;
        }
    }
}