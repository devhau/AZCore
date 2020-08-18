using HtmlAgilityPack;
using SpiderBotTool.Proxy;

namespace SpiderBotTool.common
{
    public class WebBaseBot
    {
        public string GetHtml(string url)
        {
            ProxyRequest request = new kproxy();
            return request.GetHtmlRequest(url);
        }
        public HtmlNode GetDoc(string url)
        {
            var html = new HtmlAgilityPack.HtmlDocument();
            html.LoadHtml(GetHtml(url));
            return html.DocumentNode;
        }
    }
}
