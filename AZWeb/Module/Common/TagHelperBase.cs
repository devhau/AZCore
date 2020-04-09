using AZWeb.Module.Constant;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace AZWeb.Module.Common
{
    public class TagHelperBase: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string TagId { get; private set; }
        [HtmlAttributeName("class")]
        public virtual string TagClass { get; set; } 
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        protected HttpContext HttpContext => ViewContext?.HttpContext;
        protected string Title { get => Html.Title; set => Html.Title = value; }
        protected string Description { get => Html.Description; set => Html.Description = value; }
        protected string Keyword { get => Html.Keyword; set => Html.Keyword = value; }
        protected HtmlContent Html { get => this.HttpContext.Items[AZWebConstant.Html] as HtmlContent; }
        public void AddMeta(string name, string content)
        {
            this.Html.AddMeta(name, content);
        }
        public void AddJS(string Code, string link= "", string CDN = "")
        {
            this.Html.AddJS(Code, link, CDN);
        }
        public void AddCSS(string Code, string link = "", string CDN = "")
        {
            this.Html.AddCSS(Code, link, CDN);
        }
        public override void Init(TagHelperContext context)
        {
            this.TagId = string.Format("az{0}", Guid.NewGuid().ToString().Replace("-", ""));
            base.Init(context);
        }

    }
}
