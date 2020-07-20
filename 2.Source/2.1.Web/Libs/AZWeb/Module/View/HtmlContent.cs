using AZCore.Extensions;
using AZWeb.Configs;
using System.Collections.Generic;
using System.Linq;

namespace AZWeb.Module.View
{
    public class HtmlContent
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Html { get; set; }
        public List<MetaContent> Meta { get; } = new List<MetaContent>();
        public List<ContentTag> JS { get; } = new List<ContentTag>();
        public List<ContentTag> CSS { get; } = new List<ContentTag>();

        public void AddMeta(string name, string content) {
            this.Meta.Add(new MetaContent() { Name=name,Content=content});
        }
        public void AddJS(string Code, string link, string CDN,int Order = 1)
        { 
            if (!Code.IsNullOrEmpty() && this.JS.Any(p => p.Code == Code)) return;
            if (!link.IsNullOrEmpty() && this.JS.Any(p => p.Link == link)) return;
            if (!CDN.IsNullOrEmpty() && this.JS.Any(p => p.CDN == CDN)) return;
            this.JS.Add(new ContentTag() { Link = link, CDN = CDN , Code = Code,Order = Order });
        }
        public void AddCSS(string Code, string link, string CDN, int Order = 1)
        {
            if (!Code.IsNullOrEmpty() && this.CSS.Any(p => p.Code == Code)) return;
            if (!link.IsNullOrEmpty() && this.CSS.Any(p => p.Link == link)) return;
            if (!CDN.IsNullOrEmpty() && this.CSS.Any(p => p.CDN == CDN)) return;
            this.CSS.Add(new ContentTag() { Link = link, CDN = CDN, Code = Code, Order = Order });
        }
    }
    public class MetaContent
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
