using AZWeb.Common.Module.View;
using AZWeb.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;

namespace AZWeb.Common
{
    public class AZTagHelper : TagHelper
    {
        protected readonly object TagLock = new object();
        public string TagId { get; private set; }
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public IHtmlView Html { get => this.ViewContext.HttpContext.GetContetModule(); }
        public void AddJS(string js)
        {
            Html.JS.Add(new Configs.ContentTag() { Code = js });
        }
        public override void Init(TagHelperContext context)
        {
            this.TagId = string.Format("az{0}", Guid.NewGuid().ToString().Replace("-", ""));
            base.Init(context);
        }
    }
}