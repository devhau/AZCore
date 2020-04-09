using AZWeb.Configs;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;

namespace AZWeb.Module.View
{
    public class HtmlContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keyword { get; set; }
        public string Html { get; set; }
        public List<MetaContent> Meta { get; } = new List<MetaContent>();
        public List<ContentTag> JS { get; } = new List<ContentTag>();
        public List<ContentTag> CSS { get; } = new List<ContentTag>();

        public void AddMeta(string name, string content) {
            this.Meta.Add(new MetaContent() { Name=name,Content=content});
        }
        public void AddJS(string Code, string link, string CDN)
        {
            this.JS.Add(new ContentTag() { Link = link, CDN = CDN , Code = Code });
        }
        public void AddCSS(string Code, string link, string CDN)
        {
            this.CSS.Add(new ContentTag() { Link = link, CDN = CDN, Code = Code });
        }
    }
    public class MetaContent
    {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
