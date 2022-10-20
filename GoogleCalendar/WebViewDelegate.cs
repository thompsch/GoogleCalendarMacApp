using System;
using System.Threading.Tasks;
using ObjCRuntime;
using WebKit;
using Xamarin.Essentials;

namespace GoogleCalendar
{
    public class WebViewDelegate : WKNavigationDelegate
    {
        public WebViewDelegate()
        {
        }


        public override void DecidePolicy(WKWebView webView,
            WKNavigationAction navigationAction,
            Action<WKNavigationActionPolicy> decisionHandler)
        {
            if (navigationAction.Request.Url.ToString().Contains("https://www.google.com/url?q"))
            {
                var url = navigationAction.Request.Url.ToString();
                if (url.Contains("http"))
                {
                    try
                    {
                        var uri = new Uri(url);
                        Launcher.OpenAsync(uri);
                    }
                    catch (Exception)
                    {
                    }
                }
                decisionHandler(WKNavigationActionPolicy.Cancel);
            }
            else decisionHandler(WKNavigationActionPolicy.Allow);
        }
    }
}

