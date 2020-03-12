using Gecko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotYoutube
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Xpcom.Initialize("Firefox"); 
            GeckoPreferences.User["gfx.font_rendering.graphite.enabled"] = true;
            GeckoPreferences.User["privacy.donottrackheader.enabled"] = true;
            GeckoPreferences.User["general.useragent.override"] = "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:59.0) Gecko/20100101 Firefox/59.0";
            Application.Run(new FormMain());
        }
    }
}
