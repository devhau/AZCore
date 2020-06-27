using AZCore.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZWeb.Module.TagHelper.Module
{
    internal class TabPageContent
    {
        public const string Key = "az_TabPageContent";
        public string Title { get; set; }
        public string Html { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string Id { get; set; }
    }
    [HtmlTargetElement("az-tab-control")]
    public class AZTabControl : TagHelperBase
    {
        public bool IsLink { get; set; } = false;
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            HttpContext.Items[TabPageContent.Key] = new List<TabPageContent>();
            await output.GetChildContentAsync();
            var pages = HttpContext.Items[TabPageContent.Key].As<List<TabPageContent>>();
            var isActive = pages.Any(p=>p.IsActive);
            var isFlgs = false;
            htmlBuild.AppendFormat("<div class='az-tab-control {0}' {1}>",this.TagClass,Attr);
            htmlBuild.Append("<ul class='nav nav-tabs' role='tablist'>");
            foreach(var item in pages)
            {
                htmlBuild.Append("<li class='nav-item' role='presentation'>");
                if (IsLink)
                {
                    if (!isFlgs && (!isActive || item.IsActive))
                    {
                        isFlgs = true;
                        htmlBuild.AppendFormat("<a class='nav-link active show' id='{1}-tab'  href='{2}' role='tab' aria-controls='{1}' aria-selected='false'>{0}</a>", item.Title, item.Id, item.Link);
                    }
                    else
                    {
                        htmlBuild.AppendFormat("<a class='nav-link' id='{1}-tab'  href='{2}' role='tab' aria-controls='{1}' aria-selected='false'>{0}</a>", item.Title, item.Id, item.Link);
                    }
                }
                else
                {
                    if (!isFlgs && (!isActive || item.IsActive))
                    {
                        isFlgs = true;
                        htmlBuild.AppendFormat("<a class='nav-link active show' id='{1}-tab' data-toggle='tab' href='#{1}' role='tab' aria-controls='{1}' aria-selected='false'>{0}</a>", item.Title, item.Id, item.Link);
                    }
                    else
                    {
                        htmlBuild.AppendFormat("<a class='nav-link' id='{1}-tab' data-toggle='tab' href='#{1}' role='tab' aria-controls='{1}' aria-selected='false'>{0}</a>", item.Title, item.Id, item.Link);
                    }
                }
               
                htmlBuild.Append("</li>");
            }
            htmlBuild.Append("</ul>");
            htmlBuild.Append("<div class='tab-content'>");
            isFlgs = false;
            foreach (var item in pages)
            {
                if (!isFlgs && (!isActive || item.IsActive))
                {
                    isFlgs = true;
                    htmlBuild.AppendFormat("<div class='tab-pane fade show active' id='{0}' role='tabpanel' aria-labelledby='{0}-tab'>{1}</div>", item.Id, item.Html);
                }
                else
                {
                    htmlBuild.AppendFormat("<div class='tab-pane fade' id='{0}' role='tabpanel' aria-labelledby='{0}-tab'>{1}</div>", item.Id, item.Html);
                }
            }
            htmlBuild.Append("</div>");
            htmlBuild.Append("</div>");
            HttpContext.Items.Remove(TabPageContent.Key);
            await Task.CompletedTask;
        }
    }

    [HtmlTargetElement("az-tab-page",ParentTag = "az-tab-control")]
    public class AZTabPage : TagHelperBase
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            var html = await output.GetChildContentAsync();
            HttpContext.Items[TabPageContent.Key].As<List<TabPageContent>>().Add(new TabPageContent()
            {
                Id=this.TagId,
                Title = Name,
                Html = html.GetContent(),
                Link = Link
            });
            await Task.CompletedTask;
        }
    }
}
