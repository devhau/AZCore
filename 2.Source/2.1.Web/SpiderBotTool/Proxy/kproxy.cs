using Flurl.Http;
using SpiderBotTool.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SpiderBotTool.Proxy
{
    public class kproxy : ProxyRequest
    {
        public override string GetHtmlRequest(string url, string method = "GET", object data = null)
        {
            var rs= url.GetStringAsync().ConfigureAwait(true).GetAwaiter().GetResult();
           
            return rs;
            //  if(ProxyCurrent==null)ProxyCurrent= Proxys.OrderBy(p => r.Next(100000000)).First();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            // lock (r)
            request.UserAgent = UserAgents.OrderBy(p => r.Next(100000000)).First();
            //  request.Proxy = getWebProxy(ProxyCurrent);
            request.Timeout = 2000;
            //frmMain.WriteLog(request.UserAgent);
            //   request.UseDefaultCredentials = true;

            request.Method = "GET";
            String html = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                html = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            return html;
        }
    }
}
