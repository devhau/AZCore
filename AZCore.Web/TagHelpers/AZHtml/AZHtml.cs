using AZCore.Web.Common;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using System.Threading.Tasks;
using Yahoo.Yui.Compressor;

namespace AZCore.Web.TagHelpers.AZHtml
{
    [HtmlTargetElement("az-html")]
    public class AZHtml : AZTagHelper
    {
        [HtmlAttributeName("class")]
        public string ClassHtml { get; set; } = "hold-transition sidebar-mini layout-navbar-fixed";
        [HtmlAttributeName("lang")]
        public string LangHtml { get; set; } = "en";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            var content = await output.GetChildContentAsync();
            var htmlDoc = content.GetContent().LoadHtml();
            var headHtml = htmlDoc.DocumentNode.Descendants("head");
            var bodyHtml = htmlDoc.DocumentNode.Descendants("body");
            #region << Init Html >>
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<!DOCTYPE html>");
            htmlBuilder.Append($"<html lang=\"{LangHtml}\" >");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append("<meta charset=\"utf-8\">");
            htmlBuilder.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            htmlBuilder.Append($"<title>{this.HtmlResult.Title}</title>");
            //<meta name=\"description\" content=\"{this.HtmlResult.Title}\">
            htmlBuilder.Append($"<meta name=\"description\" content=\"{this.HtmlResult.Description}\">");
            htmlBuilder.Append($"<meta name=\"keywords\" content=\"{this.HtmlResult.Keywords}\">");
            htmlBuilder.Append($"<meta name=\"author\" content=\"{this.HtmlResult.Author}\">");
            foreach (var item in headHtml)
            {
                htmlBuilder.Append(item.InnerHtml.ToString());
            }
            foreach (var item in this.HtmlResult.CSS)
            {
                if (!string.IsNullOrEmpty(item.Code))
                {
                    var styleCssEl = new TagBuilder("style");
                    styleCssEl.Attributes.Add("type", "text/css");
                    styleCssEl.Attributes.Add("rel", "stylesheet");
                    styleCssEl.InnerHtml.Append(item.Code);
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
            htmlBuilder.Append("</head>");
            htmlBuilder.Append($"<body class=\"{ClassHtml}\" onhashchange=\"return;\">");
            foreach (var item in bodyHtml)
            {
                htmlBuilder.Append(item.InnerHtml.ToString());
            }
            var jsCompressor = new JavaScriptCompressor();
            foreach (var item in this.HtmlResult.JS)
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
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");
            #endregion
            output.Content.SetHtmlContent(htmlBuilder.ToString());
            //string html = ViewContext.HttpContext.RequestServices.GetRequiredService<ModulePortal>().GetTheme().GetHtml(); ;
            //output.Content.SetHtmlContent(html);

        }
    }
}
