using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpiderBotTool.common
{
    public class WebBaseBot
    {
        public HtmlNode GetDoc(string url)
        {
            var web1 = new HtmlWeb();
            var html = web1.Load(url);
            return html.DocumentNode;
        }
    }
}
