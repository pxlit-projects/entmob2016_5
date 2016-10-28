using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TTT_Test_Final
{
    public partial class App : Application
    {
        private Device_Scan device_Scan;

        public App()
        {
            InitializeComponent();
            MainPage = new TTT_Test_Final.Device_Scan();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
