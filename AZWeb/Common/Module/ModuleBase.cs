﻿using AZCore.Domain;
using AZCore.Extensions;
using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AZWeb.Common.Module
{
    public interface IModule: IAZTransient
    {
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string Keywords { get; set; }
        HttpContext httpContext { get; }
    }
    public abstract class ModuleBase : IModule
    {
        protected virtual void IntData() { }
        public string h { get; set; }
        private static Regex regexModule = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);
        private static Regex regexError = new Regex("Web.([A-Za-z0-9]+).([A-Za-z0-9]+)$", RegexOptions.IgnoreCase);

        public HttpContext httpContext { get; private set; }
        public IViewResult HtmlResult { get => this.httpContext.GetContetModule(); }
        public IPagesConfig PagesConfig { get; }
        public string Title{ get => HtmlResult.Title; set => HtmlResult.Title = value; }
        public string Description { get => HtmlResult.Description; set => HtmlResult.Description = value; }
        public string Author { get => HtmlResult.Author; set => HtmlResult.Author = value; }
        public string Keywords { get => HtmlResult.Keywords; set => HtmlResult.Keywords = value; }
        public string Html { get => HtmlResult.Html; set => HtmlResult.Html = value; }
        public bool IsTheme { get => HtmlResult.IsTheme; set => HtmlResult.IsTheme = value; }
        public string LayoutTheme { get; set; } = "LayoutTheme";
        public ModuleBase(IHttpContextAccessor httpContext) {
            this.httpContext = httpContext.HttpContext;
            IsTheme = true;
            PagesConfig = this.httpContext.GetService<IPagesConfig>();
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
            this.Html = html;
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
            IntData();
            var methodFunction = this.GetType().GetMethod(string.Format("{0}{1}", this.httpContext.Request.Method.ToUpperFirstChart(), this.h.ToUpperFirstChart()));
            if (methodFunction==null) {
                return null;
            }
            var paras = methodFunction.GetParameters();
            List<object> paraValues = new List<object>();
            foreach (var item in paras)
            {
                if (this.httpContext.Request.Query.ContainsKey(item.Name.ToLower()))
                {
                    if (item.ParameterType.IsArray)
                    {
                        var type = item.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Query[item.Name][0].Split(',').Select(p => Convert.ChangeType(p, type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(Convert.ChangeType(this.httpContext.Request.Query[item.Name].ToArray()[0], item.ParameterType));
                    }

                }
                else if (this.httpContext.Request.HasFormContentType&& this.httpContext.Request.Form.Keys.Contains(item.Name.ToLower())) {
                    if (item.ParameterType.IsArray)
                    {
                        var type = item.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Form[item.Name][0].Split(',').Select(p => Convert.ChangeType(p, type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(Convert.ChangeType(this.httpContext.Request.Form[item.Name].ToArray()[0], item.ParameterType));
                    }

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
                if ((IViewResult)rsObj!=null)
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
        public virtual void RenderSite() {
            httpContext.Response.WriteAsync(this.Html);
        }
    }
}