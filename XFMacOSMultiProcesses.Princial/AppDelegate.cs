using System;
using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace XFMacOSMultiProcesses.Princial
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
		private NSWindow _window;
		public override NSWindow MainWindow
		{
			get { return _window; }
		}

		public AppDelegate()
        {
			ObjCRuntime.Runtime.MarshalManagedException += (sender, args) =>
			{
				Console.WriteLine(args.Exception);
			};

			var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

			var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
			_window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
			_window.Title = "Principal";
			_window.TitleVisibility = NSWindowTitleVisibility.Hidden;
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			Forms.Init();
			var app = new App();
			LoadApplication(app);
			base.DidFinishLaunching(notification);
		}
	}
}
