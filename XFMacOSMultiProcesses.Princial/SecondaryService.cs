using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AppKit;
using Xamarin.Forms;
using XFMacOSMultiProcesses.Princial;

[assembly: Dependency(typeof(SecondaryService))]
namespace XFMacOSMultiProcesses.Princial
{
    public class SecondaryService : ISecondaryService
    {
        public SecondaryService()
        {
        }

        public async Task StartNewProcessAsync()
        {
			var currentDirectory = Environment.CurrentDirectory;
			var appContentPath = Environment.CurrentDirectory;
			//var macOSPath = System.IO.Path.Combine(appContentPath.ToString(), "XFMacOSMultiProcesses.Secondary.app/Contents/MacOS/XFMacOSMultiProcesses.Secondary");
			var macOSPath = "/Applications/XFMacOSMultiProcesses.Secondary.app/Contents/MacOS/XFMacOSMultiProcesses.Secondary";
			var psi = new ProcessStartInfo
			{
				FileName = macOSPath,
				Arguments = "-c",
				UseShellExecute = false,
				CreateNoWindow = true
			};

			try
			{
				var p = Process.Start(psi);
				if (p == null)
				{

					Console.Write("processo nulo");
				}

				NSRunningApplication app = null;
				while (app == null)
				{
					app = NSRunningApplication.GetRunningApplication(p.Id);
					if (app != null)
					{
						app.Activate(NSApplicationActivationOptions.ActivateAllWindows);
					}
					else
					{
						await Task.Delay(1000);
					}
				}


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
