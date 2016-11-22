using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace TTT_Xamarin.Pages.Parts
{
    public class ListView : Xamarin.Forms.ListView
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public static BindableProperty ItemClickCommandProperty = BindableProperty.Create<ListView, ICommand>(x => x.ItemClickCommand, null);
#pragma warning restore CS0618 // Type or member is obsolete

        public ListView()
        {
            this.ItemTapped += this.OnItemTapped;
        }


        public ICommand ItemClickCommand
        {
            get { return (ICommand)this.GetValue(ItemClickCommandProperty); }
            set { this.SetValue(ItemClickCommandProperty, value); }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && this.ItemClickCommand != null && this.ItemClickCommand.CanExecute(e))
            {
                this.ItemClickCommand.Execute(e.Item);
                this.SelectedItem = null;
            }
        }
    }
}
