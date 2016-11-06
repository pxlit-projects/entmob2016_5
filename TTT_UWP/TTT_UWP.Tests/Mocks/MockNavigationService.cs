using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT_UWP.Services;

namespace TTT_UWP.Tests.Mocks
{
    public class MockNavigationService : INavigationService
    {
        public void GoBack()
        {
        }

        public void Navigate(Type sourcePage)
        {
        }

        public void Navigate(Type sourcePage, object parameter)
        {
        }
    }
}
