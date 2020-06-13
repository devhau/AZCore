using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Module.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Org.BouncyCastle.Crypto.Tls;
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
        static CssCompressor cssCompressor = new CssCompressor();
        private void RenderCss(StringBuilder htmlBuilder, List<ContentTag> Css) {
            if (Css == null) return;
            string codeCss = string.Empty;
            foreach (var item in Css)
            {
                if (!string.IsNullOrEmpty(item.Code))
                {
                    codeCss += item.Code + " ";
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
               if (!string.IsNullOrEmpty(codeCss)) {
                var styleCssEl = new TagBuilder("style");
                styleCssEl.Attributes.Add("type", "text/css");
                styleCssEl.Attributes.Add("rel", "stylesheet");
                styleCssEl.InnerHtml.AppendHtml( cssCompressor.Compress(codeCss));
                htmlBuilder.Append(styleCssEl.GetString());
            }
        }
        static JavaScriptCompressor jsCompressor = new JavaScriptCompressor()
        {
            ObfuscateJavascript = false,
            CompressionType=CompressionType.Standard,
            IgnoreEval=true
        };
        private void RenderJS(StringBuilder htmlBuilder, List<ContentTag> JS)
        {
            if (JS == null) return;
            string codeJs = string.Empty;
            foreach (var item in JS)
            {
                if (!string.IsNullOrEmpty(item.Code))
                {
                    if(item.Code.Trim().Length>0)
                    codeJs += item.Code.Trim()+" ; ";
                }
                else
                if (!string.IsNullOrEmpty(item.CDN))
                {
                    var scriptEl = new TagBuilder("script");
                    scriptEl.Attributes.Add("type", "text/javascript");
                    scriptEl.Attributes.Add("src", item.CDN);
                    htmlBuilder.Append(scriptEl.GetString());
                }
                else
                if (!string.IsNullOrEmpty(item.Link))
                {
                    var scriptEl = new TagBuilder("script");
                    scriptEl.Attributes.Add("type", "text/javascript");
                    scriptEl.Attributes.Add("src", item.Link);
                    htmlBuilder.Append(scriptEl.GetString());
                }
            }
            codeJs = codeJs.Trim();
            if (!string.IsNullOrEmpty(codeJs)) {

                var scriptEl = new TagBuilder("script");
                scriptEl.Attributes.Add("type", "text/javascript");
                scriptEl.InnerHtml.AppendHtml("$(function(){ " + jsCompressor.Compress(codeJs) + " });");
                htmlBuilder.Append(scriptEl.GetString());

            }
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output, StringBuilder htmlBuild)
        {
            var content = await output.GetChildContentAsync();
            var htmlDoc = content.GetContent().LoadHtml();
            var headHtml = htmlDoc.DocumentNode.Descendants("head");
            var bodyHtml = htmlDoc.DocumentNode.Descendants("body");
            htmlBuild.Append("<!DOCTYPE html>");
            htmlBuild.Append($"<html lang=\"{LangHtml}\" >");
            htmlBuild.Append("<head>");
            htmlBuild.Append("<meta charset=\"utf-8\">");
            htmlBuild.Append("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            htmlBuild.Append($"<title>{this.Title}</title>");
            htmlBuild.Append($"<meta name=\"description\" content=\"{this.Description}\">");
            htmlBuild.Append($"<meta name=\"keywords\" content=\"{this.Keyword}\">");
            if (this.Html.Meta != null)
                foreach (var item in this.Html.Meta)
                {
                    htmlBuild.Append($"<meta name=\"{item.Name}\" content=\"{item.Content}\">");
                }
            foreach (var item in headHtml)
            {
                htmlBuild.Append(item.InnerHtml.ToString());
            }
            //Css in function
            RenderCss(htmlBuild, this.Html.CSS);
            htmlBuild.Append("</head>");
            htmlBuild.Append($"<body class=\"{TagClass}\" >");
            foreach (var item in bodyHtml)
            {
                htmlBuild.Append(item.InnerHtml.ToString());
            }
            RenderJS(htmlBuild, this.Html.JS);
            htmlBuild.Append("</body>");
            htmlBuild.Append("</html>");
           await Task.CompletedTask;
        }
    }
}
