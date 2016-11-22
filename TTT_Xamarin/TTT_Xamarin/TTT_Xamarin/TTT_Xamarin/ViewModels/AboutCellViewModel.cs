using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_Xamarin.Pages.Parts;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
namespace TTT_Xamarin.ViewModels
{
    class AboutCellViewModel:BindableObject
    {
        private BindableProperty headerProperty;
        private BindableProperty textProperty;

        public string Header { get { return (string)GetValue(headerProperty); } }
        public string Text { get { return (string)GetValue(textProperty); } }
        public AboutCellViewModel(BindableProperty headerProperty, BindableProperty textProperty)
        {
            this.headerProperty = headerProperty;
            this.textProperty = textProperty;
        }
    }
}
