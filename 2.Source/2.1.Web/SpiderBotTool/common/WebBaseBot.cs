using HtmlAgilityPack;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SpiderBotTool.common
{
    public class WebBaseBot
    {
        public string GetHtml(string url) {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (iPad; CPU OS 6_0 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10A5355d Safari/8536.25";
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
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
        public HtmlNode GetDoc(string url)
        {
            var html = new HtmlDocument();
            html.LoadHtml(GetHtml(url));
            return html.DocumentNode;
        }
    }
}
