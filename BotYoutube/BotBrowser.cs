using BotYoutube.Tasks;
using Gecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    public class BotBrowser: GeckoWebBrowser
    {
        public void WaitUtilDone()
        {
            do { BotWorker.Sleep(500);} while (this.IsBusy&& !BotWorker.IsStop);
        }
        public void ChangeProxy(string http, int port, int type = 1)
        {
            GeckoPreferences.Default.Reset();
            GeckoPreferences.Default["network.proxy.type"] = type;
            GeckoPreferences.Default["network.proxy.http"] = http;
            GeckoPreferences.Default["network.proxy.http_port"] = port;
            GeckoPreferences.Default["network.proxy.ssl"] = http;
            GeckoPreferences.Default["network.proxy.ssl_port"] = port;
            this.Reload();
        }
        public void GoToTop()
        {
            this.Window.ScrollTo(0, 0);
        }
        public void GoToBottom()
        {
            this.Window.ScrollTo(this.Window.ScrollMaxX / 2, this.Window.ScrollMaxY);
        }
        public void GoToCenter()
        {
            this.Window.ScrollTo(this.Window.ScrollMaxX / 2, this.Window.ScrollMaxY / 2);
        }
        public void GoToSubYoutube()
        {
            GoToBottom();
            WaitUtilDone();
            BotWorker.Sleep(500);
            this.Window.ScrollTo(this.Window.ScrollMaxX / 2,(int) this.Window.ScrollY + 100);
            WaitUtilDone();
            BotWorker.Sleep(500);
            this.Window.ScrollTo(this.Window.ScrollMaxX / 2, (int)this.Window.ScrollY + 100);
        }
    }
}
