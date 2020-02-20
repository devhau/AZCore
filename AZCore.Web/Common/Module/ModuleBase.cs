using AZCore.Extensions;
using AZCore.Web.Configs;
using AZCore.Web.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AZCore.Web.Common.Module
{
    public class ModuleBase : IModule
    {
        public string h { get; set; }
        private static Regex regexModule = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);
        private static Regex regexError = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);

        public HttpContext httpContext { get; private set; }
        public IViewResult HtmlResult { get => this.httpContext.GetContetModule(); }
        public IPagesConfig PagesConfig { get => this.httpContext.GetService<IPagesConfig>(); }
        public string Title { get; set; } = "Hệ thống quản lý nhân sự";
        public string Description { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public bool IsTheme { get; set; } = true;
        public string LayoutTheme { get; set; } = "LayoutTheme";
        public ModuleBase(IHttpContextAccessor httpContext) {
            this.httpContext = httpContext.HttpContext;
            this.httpContext.BindRequestTo(this);
        }

        protected IViewResult View(){
            return View(this);
        }
        protected IViewResult View(object mode)
        {
            return View(null, mode);
        }
        protected IViewResult View(string viewName, object mode)
        {
            return GetView(RenderHtml(viewName, mode));
        }
        protected IViewResult GetView(string html)
        {
            this.HtmlResult.Html = html;
            this.HtmlResult.Title = this.Title;
            this.HtmlResult.Description = this.Description;
            this.HtmlResult.Author = this.Author;
            this.HtmlResult.Keywords = this.Keywords;
            this.HtmlResult.IsTheme = this.IsTheme;
            return this.HtmlResult;

        }
        protected virtual string RenderHtml(object mode) {            
            return RenderHtml(null,mode);
        }
        protected virtual string RenderHtml(string viewName=null,object mode=null)
        {
            Type type = this.GetType();
            if (regexError.IsMatch(type.FullName))
            {
                var m = regexError.Match(type.FullName);
                if (mode == null) mode = this;
                if (string.IsNullOrEmpty(viewName)) viewName = m.Groups[2].Value;
                return this.httpContext.RenderToHtml(string.Format("~/Web/{0}", m.Groups[1].Value), viewName + ".cshtml", mode);
            }
            else if (regexModule.IsMatch(type.FullName))
            {
                var m = regexModule.Match(type.FullName);
                if (mode == null) mode = this;
                if (string.IsNullOrEmpty(viewName)) viewName = m.Groups[3].Value;
                return this.httpContext.RenderToHtml(string.Format("~/Web/{0}/{1}", m.Groups[1].Value, m.Groups[2].Value), viewName + ".cshtml", mode);
            }
            return string.Empty;
        }
        internal virtual IViewResult GetView()
        {
            var methodFunction = this.GetType().GetMethod(string.Format("{0}{1}", this.httpContext.Request.Method.ToUpperFirstChart(), this.h.ToUpperFirstChart()));
            var paras = methodFunction.GetParameters();
            List<object> paraValues = new List<object>();
            foreach (var item in paras)
            {
                if (false && this.httpContext.Request.Query.ContainsKey(item.Name))
                {
                    paraValues.Add(Convert.ChangeType(this.httpContext.Request.Query[item.Name], item.ParameterType));
                }
                else
                {
                    if (item.HasDefaultValue)
                        paraValues.Add(item.RawDefaultValue);
                    else
                        paraValues.Add(null);
                }
            }
            var rsObj = methodFunction.Invoke(this, paraValues.ToArray());
            if (rsObj != null)
            {
                if (rsObj.GetType() == typeof(ViewResult))
                {
                    return (IViewResult)rsObj;
                }
                else
                {
                    return GetView(rsObj.ToString());
                }
            }
            return GetView("");
        }

        public override string ToString()
        {
            return RenderHtml();
        }
    }
}
