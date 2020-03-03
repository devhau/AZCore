using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using AZWeb.Common.Module;
using AZWeb.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using AZCore.Extensions;

namespace AZWeb.Extensions
{
    public static class HttpContextExtensions
    {
        public static string RenderToHtml(this HttpContext httpContext,string path,string viewName, object model) {

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var _razorViewEngine = httpContext.GetService<IRazorViewEngine>();
            var _tempDataProvider= httpContext.GetService<ITempDataProvider>();
            
            using (var sw = new StringWriter())
            {
                var viewResult = _razorViewEngine.GetView(path+"/"+ viewName, viewName, false);
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(
                    actionContext,
                    viewResult.View,
                    viewDictionary,
                    new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                    sw,
                    new HtmlHelperOptions()
                );

                var rs = viewResult.View.RenderAsync(viewContext);
                rs.Wait();
                return sw.ToString();
            }
        }
        public static void BindRequestTo( this HttpContext httpContext,object obj) {
            var objType = obj.GetType();
            foreach (var item in httpContext.Request.Query.Keys) {
                var pro = objType.GetProperty(item);
                if (pro != null && pro.CanWrite) {
                    if (pro.PropertyType.IsArray)
                    {
                        pro.SetValue(obj, httpContext.Request.Query[item]);
                    }
                    else {
                        pro.SetValue(obj, httpContext.Request.Query[item][0]);
                    }
                    
                }
             }
        }
        public static bool IsAjax(this HttpContext httpContext) {

            if (httpContext == null)
                throw new ArgumentNullException(nameof(httpContext));
            return httpContext.Request.IsAjax();

        }
        /// <summary>
        /// Determines whether the specified HTTP request is an AJAX request.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified HTTP request is an AJAX request; otherwise, false.
        /// </returns>
        /// <param name="request">The HTTP request.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> parameter is null (Nothing in Visual Basic).</exception>
        public static bool IsAjax(this HttpRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
        public static IViewResult GetContetModule(this HttpContext httpContext) {
            if (httpContext.Items[AZCoreWeb.KeyHtmlModule] == null) { httpContext.Items[AZCoreWeb.KeyHtmlModule] = new Common.Module.ViewResult(); }
            return httpContext.Items[AZCoreWeb.KeyHtmlModule] as IViewResult;
        }
        public static TClass GetService<TClass>(this HttpContext httpContext) {
            return httpContext.RequestServices.GetRequiredService<TClass>();
        }
        public static TClass GetService<TClass>(this HttpContext httpContext,Type type)
        {
            return (TClass)httpContext.RequestServices.GetRequiredService(type) ;
        }
        public static void SetCookie<TClass>(this HttpContext httpContext, string key, TClass obj, int? expireTime)
        {
            httpContext.Response.Cookies.SetCookie<TClass>(key, obj, expireTime);
        }
        public static void SetCookie<TClass>(this IResponseCookies cookie, string key, TClass obj, int? expireTime)
        {
            cookie.SetCookie(key,obj.ToJson(),expireTime);
        }
        public static void SetCookie(this HttpContext httpContext, string key, string obj, int? expireTime)
        {
            httpContext.Response.Cookies.SetCookie(key, obj, expireTime);
        }
        public static void SetCookie(this IResponseCookies cookie, string key, string obj, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddDays(2);
            cookie.Append(key, obj);
        }
        public static TClass GetCookie<TClass>(this HttpContext httpContext, string key) where TClass : class
        {
            return httpContext.Request.Cookies.GetCookie<TClass>(key);
        }
        public static TClass GetCookie<TClass>(this IRequestCookieCollection cookie, string key) where TClass : class
        {
            var str = cookie[key];
            if (str.IsNull())
            {
                return null;
            }
            return str.ToObject<TClass>();
        }
        public static string GetCookie(this HttpContext httpContext, string key)
        {
            return httpContext.Request.Cookies.GetCookie(key);
        }
        public static string GetCookie(this IRequestCookieCollection cookie, string key)
        {
            var str = cookie[key];
            if (str.IsNull())
            {
                return null;
            }
            return str;
        }
        public static void SetSession<TClass>(this HttpContext httpContext, string key, TClass obj)
        {
            httpContext.Session.SetSession<TClass>(key, obj);
        }
        public static void SetSession<TClass>( this ISession session,string key, TClass obj) {
            session.SetString(key, obj.ToJson());
        }
        public static TClass GetSession<TClass>(this HttpContext httpContext, string key) where TClass : class
        {
            return httpContext.Session.GetSession<TClass>(key);
        }
        public static TClass GetSession<TClass>(this ISession session, string key) where TClass:class
        {
            var str = session.GetString(key);
            if (str.IsNull()) {
                return null;
            }
            return str.ToObject<TClass>();
        }
    }
}
