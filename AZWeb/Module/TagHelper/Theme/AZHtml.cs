using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yahoo.Yui.Compressor;

namespace AZWeb.Module.TagHelper.Theme
{
    [HtmlTargetElement("az-html")]
    public class AZHtml : TagHelperBase
    {       
        [HtmlAttributeName("lang")]
        public string LangHtml { get; set; } = "en";
        public override void Init(TagHelperContext context)
        {
            if (string.IsNullOrEmpty(this.TagClass)) this.TagClass = "hold-transition sidebar-mini layout-navbar-fixed";
            base.Init(context);
        }
        private void RenderCss(StringBuilder htmlBuilder, List<ContentTag> Css) {
            if (Css == null) return;
            foreach (var item in Css)
            {
                if (!string.IsNullOrEmpty(item.Code))
                {
                    var styleCssEl = new TagBuilder("style");
                    styleCssEl.Attributes.Add("type", "text/css");
                    styleCssEl.Attributes.Add("rel", "stylesheet");
                    styleCssEl.InnerHtml.AppendHtml(item.Code);
                    htmlBuilder.Append(styleCssEl.GetString());
                }
                else if (!string.IsNullOrEmpty(item.CDN))
                {
                    var libCssEl = new TagBuilder("link");
                    libCssEl.Attributes.Add("href", item.CDN);
                    libCssEl.Attributes.Add("type", "text/css");
                    libCssEl.Attributes.Add("rel", "stylesheet");
                    libCssEl.TagRenderMode = TagRenderMode.SelfClosing;
                    htmlBuilder.Append(libCssEl.GetString());
                }
                else if (!string.IsNullOrEmpty(item.Link))
                {
                    var libCssEl = new TagBuilder("link");
                    libCssEl.Attributes.Add("href", item.Link);
                    libCssEl.Attributes.Add("type", "text/css");
                    libCssEl.Attributes.Add("rel", "stylesheet");
                    libCssEl.TagRenderMode = TagRenderMode.SelfClosing;
                    htmlBuilder.Append(libCssEl.GetString());
                }
            }
        }

        JavaScriptCompressor jsCompressor = new JavaScriptCompressor();
        private void RenderJS(StringBuilder htmlBuilder, List<ContentTag> JS)
        {
            if (JS == null) return;
            foreach (var item in JS)
            {
                var scriptEl = new TagBuilder("script");
                scriptEl.Attributes.Add("type", "text/javascript");
                if (!string.IsNullOrEmpty(item.Code))
                {
                    scriptEl.InnerHtml.AppendHtml(jsCompressor.Compress(item.Code));
                }
                else
                if (!string.IsNullOrEmpty(item.CDN))
                {
                    scriptEl.Attributes.Add("src", item.CDN);
                }
                else
                if (!string.IsNullOrEmpty(item.Link))
                {
                    scriptEl.Attributes.Add("src", item.Link);
                }
                htmlBuilder.Append(scriptEl.GetString());
            }
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            var content = await output.GetChildContentAsync();
            var htmlDoc = content.GetContent().LoadHtml();
            var headHtml = htmlDoc.DocumentNode.Descendants("head");
            var bodyHtml = htmlDoc.DocumentNode.Descendants("body");
            var config = HttpContext.GetService <IPagesConfig>();
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append($"<html lang=\"{LangHtml}\" >");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<meta charset=\"utf-8\">");
            htmlBuilder.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            htmlBuilder.Append($"<title>{this.Title}</title>");
            htmlBuilder.Append($"<meta name=\"description\" content=\"{this.Description}\">");
            htmlBuilder.Append($"<meta name=\"keywords\" content=\"{this.Keyword}\">");
            if(this.Html.Meta!=null)
            foreach (var item in this.Html.Meta) {
                htmlBuilder.Append($"<meta name=\"{item.Name}\" content=\"{item.Content}\">");
            }
            foreach (var item in headHtml)
            {
                htmlBuilder.Append(item.InnerHtml.ToString());
            }
            RenderCss(htmlBuilder, config.Head.Stypes);
            RenderCss(htmlBuilder, this.Html.CSS);
            htmlBuilder.Append("</head>");
            htmlBuilder.Append($"<body class=\"{TagClass}\" >");
            foreach (var item in bodyHtml)
            {
                htmlBuilder.Append(item.InnerHtml.ToString());
            }
            RenderJS(htmlBuilder, config.Head.Scripts);
            RenderJS(htmlBuilder, this.Html.JS);
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");
            output.Content.SetHtmlContent(htmlBuilder.ToString());
        }
    }
}
