using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.IO;
using System.Collections;
using AZCore.Extensions;
using AZWeb.Module.Attributes;

namespace AZWeb.Extensions
{
    public static class HttpContextExtensions
    {
        public static string RenderToHtml(this HttpContext httpContext,string path,string viewName, object model) {

            var actionContext = new ActionContext(httpContext, httpContext.GetRouteData(), new ActionDescriptor());
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

                var rs =  viewResult.View.RenderAsync(viewContext);
                rs.Wait();
                return sw.GetStringBuilder().ToString();
            }
        }
        public static void BindQueryAttributeTo(this HttpContext httpContext, object obj)
        {
            var objType = obj.GetType();
            foreach (var item in httpContext.Request.Query.Keys)
            {
                var pro = objType.GetProperty(item);
                if (pro != null && pro.CanWrite && pro.GetAttribute<BindQueryAttribute>() != null)
                {
                    if (pro.PropertyType.IsArray)
                    {
                        pro.SetValue(obj, httpContext.Request.Query[item][0].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                    }
                    else
                    {
                        pro.SetValue(obj, httpContext.Request.Query[item][0].ToType(pro.PropertyType));
                    }

                }
            }
        }
        public static void BindFormAttributeTo(this HttpContext httpContext, object obj)
        {
            if (!httpContext.Request.HasFormContentType) return;
            var objType = obj.GetType();
            foreach (var item in httpContext.Request.Form.Keys.Where(p => p.IndexOf(".") < 0))
            {
                var pro = objType.GetProperties().FirstOrDefault(p => p.CanWrite && p.Name.Equals(item, StringComparison.OrdinalIgnoreCase));
                if (pro != null && pro.GetAttribute<BindFormAttribute>() != null)
                {
                    if (pro.PropertyType.IsArray)
                    {
                        pro.SetValue(obj, httpContext.Request.Form[item][0].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                    }
                    else
                    {
                        pro.SetValue(obj, httpContext.Request.Form[item][0].ToType(pro.PropertyType));
                    }
                }
            }
            var listKeys = httpContext.Request.Form.Keys.Where(p => p.IndexOf(".") > 0).Select(p => p.Split(new string[] { "[]", "." }, StringSplitOptions.RemoveEmptyEntries)[0]).Distinct().ToList();
            foreach (var item in listKeys)
            {
                if (httpContext.Request.Form.Keys.Any(p => p.StartsWith(string.Format("{0}.", item), StringComparison.OrdinalIgnoreCase)))
                {
                    var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}.", item), StringComparison.OrdinalIgnoreCase)).ToList();
                    var pro = objType.GetProperties().FirstOrDefault(p => p.CanWrite && p.Name.Equals(item, StringComparison.OrdinalIgnoreCase));
                    if (pro != null && pro.GetAttribute<BindFormAttribute>() != null && pro.PropertyType.IsGenericType && keys.Count > 0)
                    {

                        var objectValue = pro.PropertyType.CreateInstance();
                        foreach (var key in keys)
                        {
                            var proName = key.Split('.')[1];
                            var pro1 = pro.PropertyType.GetProperties().FirstOrDefault(p => p.Name.Equals(proName, StringComparison.OrdinalIgnoreCase));
                            if (pro1 != null && pro1.CanWrite)
                            {
                                if (pro1.PropertyType.IsArray)
                                {
                                    pro1.SetValue(objectValue, httpContext.Request.Form[key][0].Split(',').ToType(pro1.PropertyType));
                                }
                                else
                                {
                                    pro1.SetValue(objectValue, httpContext.Request.Form[key].ToArray()[0].ToType(pro1.PropertyType));
                                }
                            }
                        }
                        pro.SetValue(obj, objectValue);
                    }

                }
                else if (httpContext.Request.Form.Keys.Any(p => p.StartsWith(string.Format("{0}[].", item), StringComparison.OrdinalIgnoreCase)))
                {
                    var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}[].", item), StringComparison.OrdinalIgnoreCase)).ToList();
                    var pro = objType.GetProperties().FirstOrDefault(p => p.CanWrite && p.Name.Equals(item, StringComparison.OrdinalIgnoreCase));
                    if (pro != null && pro.GetAttribute<BindFormAttribute>() != null && pro.PropertyType.IsGenericType && pro.PropertyType.IsTypeFromInterface<IList>() && keys.Count > 0)
                    {
                        var objectValues = (IList)pro.PropertyType.CreateInstance();
                        var len = httpContext.Request.Form[keys[0]].Count;
                        var typeObject = pro.PropertyType.GetGenericArguments().Single();
                        for (var index = 0; index < len; index++)
                        {
                            var objectValue = typeObject.CreateInstance();
                            foreach (var key in keys)
                            {
                                var proName = key.Split('.')[1];
                                var pro1 = typeObject.GetProperties().FirstOrDefault(p => p.Name.Equals(proName, StringComparison.OrdinalIgnoreCase));
                                if (pro1 != null && pro1.CanWrite)
                                {
                                    if (pro1.PropertyType.IsArray)
                                    {
                                        pro1.SetValue(objectValue, httpContext.Request.Form[key][index].Split(',').ToType(pro1.PropertyType));
                                    }
                                    else
                                    {
                                        pro1.SetValue(objectValue, httpContext.Request.Form[key].ToArray()[index].ToType(pro1.PropertyType));
                                    }
                                }
                            }
                            objectValues.Add(objectValue);
                        }
                        pro.SetValue(obj, objectValues);
                    }
                }
            }
        }
        public static void BindQueryTo( this HttpContext httpContext,object obj) {
            var objType = obj.GetType();
            foreach (var item in httpContext.Request.Query.Keys) {
                var pro = objType.GetProperty(item);
                if (pro != null && pro.CanWrite) {
                    if (pro.PropertyType.IsArray)
                    {
                        pro.SetValue(obj, httpContext.Request.Query[item][0].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                    }
                    else {
                        pro.SetValue(obj, httpContext.Request.Query[item][0].ToType(pro.PropertyType));
                    }
                    
                }
             }
        }
        public static void BindFormTo(this HttpContext httpContext, object obj)
        {
            var objType = obj.GetType();
            foreach (var item in httpContext.Request.Form.Keys)
            {
                var pro = objType.GetProperty(item);
                if (pro != null && pro.CanWrite)
                {
                    if (pro.PropertyType.IsArray)
                    {
                        pro.SetValue(obj, httpContext.Request.Form[item][0].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                    }
                    else
                    {
                        pro.SetValue(obj, httpContext.Request.Form[item][0].ToType(pro.PropertyType));
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
        public static TClass GetService<TClass>(this HttpContext httpContext) {
            return httpContext.RequestServices.GetRequiredService<TClass>();
        }
        public static TClass GetService<TClass>(this HttpContext httpContext,Type type)
        {
            return (TClass)httpContext.RequestServices.GetRequiredService(type) ;
        }
        public static void RemoveCookie(this HttpContext httpContext, string key)
        {
            httpContext.Response.Cookies.RemoveCookie(key);
        }
        public static void RemoveCookie(this IResponseCookies cookie, string key)
        {
            cookie.Delete("{0}_cookie".Frmat(key));
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
            cookie.Delete("{0}_cookie".Frmat(key));
            cookie.Append("{0}_cookie".Frmat(key), obj);
        }
        public static TClass GetCookie<TClass>(this HttpContext httpContext, string key) where TClass : class
        {
            return httpContext.Request.Cookies.GetCookie<TClass>(key);
        }
        public static TClass GetCookie<TClass>(this IRequestCookieCollection cookie, string key) where TClass : class
        {
            var str = cookie["{0}_cookie".Frmat(key)];
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
            var str = cookie["{0}_cookie".Frmat(key)];
            if (str.IsNull())
            {
                return null;
            }
            return str;
        }
        public static void RemoveSession(this HttpContext httpContext, string key)
        {
            httpContext.Session.RemoveSession(key);
        }
        public static void RemoveSession(this ISession session, string key)
        {
            session.Remove("{0}_session".Frmat(key));
        }
        public static void SetSession<TClass>(this HttpContext httpContext, string key, TClass obj)
        {
            httpContext.Session.SetSession<TClass>(key, obj);
        }
        public static void SetSession<TClass>( this ISession session,string key, TClass obj) {
            session.SetString("{0}_session".Frmat(key), obj.ToJson());
        }
        public static TClass GetSession<TClass>(this HttpContext httpContext, string key) where TClass : class
        {
            return httpContext.Session.GetSession<TClass>(key);
        }
        public static TClass GetSession<TClass>(this ISession session, string key) where TClass:class
        {
            var str = session.GetString("{0}_session".Frmat(key));
            if (str.IsNull()) {
                return null;
            }
            return str.ToObject<TClass>();
        }
    }
}
