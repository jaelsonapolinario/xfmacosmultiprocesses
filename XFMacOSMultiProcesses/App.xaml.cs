using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFMacOSMultiProcesses
{
    public partial class App : Application
    {
        public App(bool isPrimary = true)
        {
            InitializeComponent();
            if (isPrimary)
                MainPage = new MainPage();
            else
                MainPage = new SecondaryPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
