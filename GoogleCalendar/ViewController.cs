using System;
using AppKit;
using Foundation;
using WebKit;

namespace GoogleCalendar
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var url = new NSUrl("https://calendar.google.com");
            var request = new NSUrlRequest(url);
            var wvd = new WebViewDelegate();
            webView.NavigationDelegate = wvd;
            webView.LoadRequest(request);
        }
        public override void ViewDidDisappear()
        {
            base.ViewDidDisappear();
            NSApplication.SharedApplication.Terminate(this);
        }
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }
    }
}
