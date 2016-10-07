using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.ViewModels;

namespace TTT_UWP
{
    public class ViewModelLocator
    {
        private static MainPageViewModel mainPageViewModel = new MainPageViewModel();
        private static DetailsPageViewModel detailsPageViewModel = new DetailsPageViewModel();

        public static MainPageViewModel MainPageViewModel
        {
            get
            {
                return MainPageViewModel;
            }
        }

        public static DetailsPageViewModel DetailsPageViewModel
        {
            get
            {
                return detailsPageViewModel;
            }
        }
    }
}
