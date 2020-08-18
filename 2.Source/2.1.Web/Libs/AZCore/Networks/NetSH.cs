using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AZCore.Networks
{
    public static class NetSH
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public static void Enable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                   new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }

        public static void Disable(string interfaceName)
        {
            System.Diagnostics.ProcessStartInfo psi =
                new System.Diagnostics.ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo = psi;
            p.Start();
        }
    }
}
