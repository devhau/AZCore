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
            do { TaskBase.Sleep(500);} while (this.IsBusy);
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
    }
}
