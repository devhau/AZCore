﻿using AZCore.Extensions;
using AZWeb.Configs;
using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Buffers;
using AZWeb.Module.Common;
using AZWeb.Module.Formatters;
using AZWeb.Module.Page;
using AZWeb.Module.View;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZWeb.Module
{
    sealed class ModuleRender
    {
        private enum RenderError
        {
            None,
            NoAuth,
            NoPermission,
            NotFoundModule,
            NotFoundMethod,
            NotFoundPath,
            NotFoundTheme,
            OK

        }
        RenderView renderView;

        HttpContext httpContext;
        IStartup startup;
        readonly IPagesConfig PageConfigs = null;
        bool IsAjax { get; }
        readonly string urlPath;
        ModuleRender(HttpContext _httpContext)
        {
            httpContext = _httpContext;
            renderView = new RenderView(httpContext);
            startup = httpContext.GetService<IStartup>();
            this.PageConfigs = this.httpContext.GetService<IPagesConfig>();
            this.IsAjax = httpContext.IsAjax();

            urlPath = this.httpContext.Request.Path.Value;
        }
        /// <summary>
        /// Get Path Real
        /// </summary>
        /// <returns> Path Real </returns>
        private string GetPathReal()
        {
            if (urlPath == "/")
            {
                return PageConfigs.UrlRealDefault;
            }
            else
            {
                foreach (var item1 in PageConfigs.Pages)
                {
                    foreach (var item2 in item1.Tags)
                    {
                        var RegexPath = new Regex(string.Format("/{0}", item2.ViturlPath));
                        if (RegexPath.IsMatch(urlPath))
                        {
                            var mPath = RegexPath.Match(urlPath);
                            List<object> paraObject = new List<object>();
                            for (var i = 1; i < mPath.Groups.Count - 1; i++)
                            {
                                paraObject.Add(mPath.Groups[i].Value);
                            }
                            if (string.IsNullOrEmpty(item2.Group))
                            return string.Format(item2.Real, paraObject.ToArray());
                            return string.Format("{0}&gm={1}", string.Format(item2.Real, paraObject.ToArray()), item2.Group);
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Load Module
        /// </summary>
        /// <param name="AssemblyModule"></param>
        /// <returns></returns>
        private PageModule LoadModule(string AssemblyModule)
        {
            var typeModule = this.GetType(AssemblyModule);
            if (typeModule != null)
            {
                return httpContext.RequestServices.GetService(typeModule) as PageModule;
            }
            return null;
        }
        /// <summary>
        /// Get Module
        /// </summary>
        /// <returns></returns>
        private async Task<RenderError> GetModule()
        {
            if (urlPath != "/" && !urlPath.EndsWith(PageConfigs.extenstion)) return RenderError.OK;
            #region --- Get Path & Merge Path ---
            var pathReal = GetPathReal();
            if (string.IsNullOrEmpty(pathReal)) return RenderError.NotFoundPath;
            foreach (var key in httpContext.Request.Query.Keys)
            {
                pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
            }
            #endregion

            #region --- Get Module & Process Module ----
            var query = QueryHelpers.ParseQuery(pathReal);
            if (!query.ContainsKey("m") || string.IsNullOrEmpty(query["m"].ToString())) return RenderError.NotFoundPath;
            string moduleName = query["m"].ToString();
            string viewName = moduleName;
            if (query.ContainsKey("v") && !string.IsNullOrEmpty(query["v"].ToString()))
                viewName = query["v"].ToString();
            string gm = "";
            if (query.ContainsKey("gm") && !string.IsNullOrEmpty(query["gm"].ToString()))
                gm = "."+query["gm"].ToString();
            string typeModuleString = string.Format("Web.Modules{2}.{0}.Form{1}", moduleName, viewName, gm);
            var ModuleCurrent = LoadModule(typeModuleString);

            var methodName = httpContext.Request.Method.ToUpperFirstChart();
            if (query.ContainsKey("h") && !string.IsNullOrEmpty(query["h"].ToString()))
                methodName = string.Format("{0}{1}", methodName, query["h"].ToString().ToUpperFirstChart());

            if (ModuleCurrent == null|| (ModuleCurrent.GetType().GetAttribute<OnlyAjaxAttribute>() != null&&!IsAjax))
                return RenderError.NotFoundModule;

            var methodFunction = ModuleCurrent.GetType().GetMethod(methodName);
            if (methodFunction == null || (methodFunction.GetAttribute<OnlyAjaxAttribute>() != null && !IsAjax))
                return RenderError.NotFoundMethod;

            ModuleCurrent.BeforeRequest();
            var isModuleAuth= ModuleCurrent.GetType().GetAttribute<AuthAttribute>()!=null;
            var isMethodAuth = methodFunction.GetAttribute<AuthAttribute>() != null;
            var isMethodNotAuth = methodFunction.GetAttribute<NotAuthAttribute>() != null;
            if (((isModuleAuth && !isMethodNotAuth) || isMethodAuth)&&!ModuleCurrent.IsAuth) {
                var redirectView = ModuleCurrent.GoToAuth().As<RedirectView>();
                if (IsAjax)
                {
                    await renderView.RenderJson(new JsonView() { Module = ModuleCurrent, StatusCode = System.Net.HttpStatusCode.Unauthorized, Data = redirectView.RedirectToUrl });
                }
                else
                {
                    httpContext.Response.Redirect(redirectView.RedirectToUrl);
                }
                return RenderError.OK;
            }
            httpContext.Request.QueryString = new QueryString(string.Format("?{0}", pathReal));

            #region Bind Param action
            List<object> paraValues = new List<object>();
            foreach (var param in methodFunction.GetParameters())
            {
                if (this.httpContext.Request.Query.ContainsKey(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Query[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(this.httpContext.Request.Query[param.Name].ToArray()[0].ToType(param.ParameterType));
                    }

                }
                else if (this.httpContext.Request.HasFormContentType  && this.httpContext.Request.Form.Keys.Contains(param.Name.ToLower()))
                {
                    if (param.ParameterType.IsArray)
                    {
                        var type = param.ParameterType.GetElementType();
                        var obj = this.httpContext.Request.Form[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                        paraValues.Add(obj);
                    }
                    else
                    {
                        paraValues.Add(this.httpContext.Request.Form[param.Name].ToArray()[0].ToType(param.ParameterType));
                    }
                }
                else
                {
                    if (param.HasDefaultValue)
                        paraValues.Add(param.RawDefaultValue);
                    else
                        paraValues.Add(null);
                }
            }
            #endregion

            Common.IView rsView = null;
            var rsFN = methodFunction.Invoke(ModuleCurrent, paraValues.ToArray());
            if (rsFN is Task)
            {
                rsView = await (Task<Common.IView>)rsFN;
            }
            else
            {
                rsView = (Common.IView)rsFN;
            }
            ModuleCurrent.AfterRequest();

            #endregion

            #region --- Check Download File && Download file ---
            if (rsView is DownloadFileView)
            {
                await renderView.RenderFile(rsView as DownloadFileView);
                return RenderError.OK;
            } else if (rsView is RedirectView) {
                await renderView.RenderRedirect(rsView as RedirectView);
                return RenderError.OK;
            } else if (rsView is JsonView)
            {
                await renderView.RenderJson(rsView as JsonView);
                return RenderError.OK;

            }
            #endregion

            #region --- Get Theme && Process Theme ---

            if (ModuleCurrent.IsTheme & !IsAjax)
            {
                string typeThemeString = string.Format("Web.Themes.{0}.LayoutTheme", PageConfigs.Theme);
                var typeTheme = this.GetType(typeThemeString);
                if (typeTheme == null)
                    return RenderError.NotFoundTheme;
                var theme = httpContext.GetService<ThemeBase>(typeTheme);

                if (theme == null)
                    return RenderError.NotFoundTheme;
                theme.BeforeRequest();
                theme.BodyContent = await renderView.GetContentHtmlFromView(rsView as HtmlView);
                await renderView.RenderHtml(theme.GetTheme());
                theme.AfterRequest();
            }
            else if (!IsAjax)
            {
                await renderView.RenderHtml(rsView as HtmlView);
            }
            else
            {
                var BodyContent = await renderView.GetContentHtmlFromView(rsView as HtmlView);
                var htmlContent = ModuleCurrent.Html;
                htmlContent.Html = BodyContent.GetString();
               await renderView.RenderJson(htmlContent);
            }
            #endregion

            return RenderError.OK;
        }
        private async Task<bool> GetError(RenderError error)
        {
            var ErrorString = "NotFound";
            string typeModuleString = string.Format("Web.Errors.{0}", ErrorString);
            var typeModule = this.GetType(typeModuleString);
            if (typeModule != null)
            {
                var errorModule = httpContext.RequestServices.GetService(typeModule) as PageModule;
                errorModule.BeforeRequest();
                var methodFunction = errorModule.GetType().GetMethod("Get");
                List<object> paraValues = new List<object>();
                foreach (var param in methodFunction.GetParameters())
                {
                    if (this.httpContext.Request.Query.ContainsKey(param.Name.ToLower()))
                    {
                        if (param.ParameterType.IsArray)
                        {
                            var type = param.ParameterType.GetElementType();
                            var obj = this.httpContext.Request.Query[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                            paraValues.Add(obj);
                        }
                        else
                        {
                            paraValues.Add(this.httpContext.Request.Query[param.Name].ToArray()[0].ToType(param.ParameterType));
                        }

                    }
                    else if (this.httpContext.Request.HasFormContentType && this.httpContext.Request.Form.Keys.Contains(param.Name.ToLower()))
                    {
                        if (param.ParameterType.IsArray)
                        {
                            var type = param.ParameterType.GetElementType();
                            var obj = this.httpContext.Request.Form[param.Name][0].Split(',').Select(p => p.ToType(type)).ToArray();
                            paraValues.Add(obj);
                        }
                        else
                        {
                            paraValues.Add(this.httpContext.Request.Form[param.Name].ToArray()[0].ToType(param.ParameterType));
                        }
                    }
                    else
                    {
                        if (param.HasDefaultValue)
                            paraValues.Add(param.RawDefaultValue);
                        else
                            paraValues.Add(null);
                    }
                }
                Common.IView rsView = null;
                var rsFN = methodFunction.Invoke(errorModule, paraValues.ToArray());
                if (rsFN is Task)
                {
                    rsView = await (Task<Common.IView>)rsFN;
                }
                else
                {
                    rsView = (Common.IView)rsFN;
                }
                errorModule.AfterRequest();
            }
            return true;
        }
       
        private async Task<bool> DoRouterAsync() {
            var statusModule = await GetModule();
            if (statusModule != RenderError.OK && statusModule != RenderError.None && statusModule != RenderError.NoAuth &&statusModule!= RenderError.NotFoundMethod)
            {
                return await GetError(statusModule);
            }
            return true;
        }
        private Type GetType(string type)
        {
            return startup.GetType(type);
        }
        public static async Task<bool> RouterAsync(HttpContext httpContext) {
            return await new ModuleRender(httpContext).DoRouterAsync();
        }
    }
}
