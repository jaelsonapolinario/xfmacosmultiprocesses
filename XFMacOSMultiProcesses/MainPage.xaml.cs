using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFMacOSMultiProcesses
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OpenNewWindow_Handle(object sender, EventArgs e)
        {
            _ = DependencyService.Get<ISecondaryService>().StartNewProcessAsync();
        }
    }
}
