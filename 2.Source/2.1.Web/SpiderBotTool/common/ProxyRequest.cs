using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SpiderBotTool.common
{
    public abstract class ProxyRequest
    {
        public static readonly Random r = new Random();
        public static readonly List<string> UserAgents = File.ReadAllLines("user-agents.txt").ToList();
        public abstract string GetHtmlRequest(string url,string method="GET",object data=null);
    }
}
