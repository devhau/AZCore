using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections;
using AZCore.Extensions;
using AZWeb.Module.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using AZWeb.Module.Constant;

namespace AZWeb.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Xử lý dữ liệu trên Query
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="obj"></param>
        public static void BindQueryAttributeTo(this HttpContext httpContext, object obj)
        {
            foreach (var pro in obj.GetType().GetPropertyByAttribute<BindQueryAttribute>())
            {
                var att = pro.GetAttribute<BindQueryAttribute>(); 
                var objValue = httpContext.GetObjectValueByQuery(pro.PropertyType, string.IsNullOrEmpty(att.FromName) ? pro.Name : att.FromName);
                if (objValue != null)
                    pro.SetValue(obj, objValue);
            }
        }
        /// <summary>
        ///  Xử lý dữ liệu trên Form
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="obj"></param>
        public static void BindFormAttributeTo(this HttpContext httpContext, object obj)
        {
            if (!httpContext.Request.HasFormContentType) return;
            foreach (var pro in obj.GetType().GetPropertyByAttribute<BindFormAttribute>())
            {
                var att = pro.GetAttribute<BindFormAttribute>();
                var objValue = httpContext.GetObjectValueByForm(pro.PropertyType, string.IsNullOrEmpty(att.FromName) ? pro.Name : att.FromName);
                if(objValue!=null)
                    pro.SetValue(obj, objValue);
            }
        }
        
        public static object GetObjectValueByQuery(this HttpContext httpContext, Type objType, string name)
        {
            if (objType.IsArray)
            {
                var typeOfElementOnObject = objType.GetElementType();

                var keys = httpContext.Request.Query.Keys.Where(p => p.StartsWith(string.Format("{0}[]", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    return null;
                var len = httpContext.Request.Query[keys[0]].Count;
                var objValues = Array.CreateInstance(typeOfElementOnObject, len);
                if (!typeOfElementOnObject.IsValueType())
                {
                    var pros = typeOfElementOnObject.GetProperties();

                    for (var i = 0; i < len; i++)
                    {
                        var objValue = typeOfElementOnObject.CreateInstance();
                        foreach (var pro in pros)
                        {
                            var key = keys.FirstOrDefault(p => p.EndsWith(string.Format("[].{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                            if (key != null) pro.SetValue(objValue, httpContext.Request.Query[key][i].ToType(pro.PropertyType));
                        }
                        objValues.SetValue(objValue, i);
                    }
                }
                else
                {
                    for (var i = 0; i < len; i++)
                    {
                        objValues.SetValue(httpContext.Request.Query[keys[0]][i].ToType(typeOfElementOnObject), i);
                    }
                }
                return objValues;
            }
            else if (objType.IsTypeFromInterface<IList>())
            {
                var objValues = objType.CreateInstance<IList>();
                var typeOfElementOnObject = objType.GetGenericArguments().Single();
                var keys = httpContext.Request.Query.Keys.Where(p => p.StartsWith(string.Format("{0}[]", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    return null;
                var len = httpContext.Request.Query[keys[0]].Count;
                if (!typeOfElementOnObject.IsValueType())
                {
                    var pros = typeOfElementOnObject.GetProperties();

                    for (var i = 0; i < len; i++)
                    {
                        var objValue = typeOfElementOnObject.CreateInstance();
                        foreach (var pro in pros)
                        {
                            var key = keys.FirstOrDefault(p => p.EndsWith(string.Format("[].{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                            if (key != null) pro.SetValue(objValue, httpContext.Request.Query[key][i].ToType(pro.PropertyType));
                        }
                        objValues.Add(objValue);
                    }
                }
                else
                {
                    for (var i = 0; i < len; i++)
                    {
                        objValues.Add(httpContext.Request.Query[keys[0]][i].ToType(typeOfElementOnObject));
                    }
                }
                return objValues;
            }
            else
                if (objType.IsValueType()) 
            {

                var key = httpContext.Request.Query.Keys.FirstOrDefault(p => p.Equals(string.Format("{0}", name), StringComparison.OrdinalIgnoreCase));
                if (key == null)
                    return null;
                return httpContext.Request.Query[key][0].ToType(objType);
            }
            else
            {
                var pros = objType.GetProperties();
                var keys = httpContext.Request.Query.Keys.Where(p => p.StartsWith(string.Format("{0}.", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    keys = httpContext.Request.Form.Keys.Where(p => p.IndexOf(".") < 0 && p.IndexOf("[]") < 0).ToList();
                if (keys.Count == 0)
                    return null;
                var objValue = objType.CreateInstance();
                foreach (var pro in pros)
                {
                    var key = keys.FirstOrDefault(p => p.EndsWith(string.Format(".{0}", pro.Name), StringComparison.OrdinalIgnoreCase) || p.Equals(string.Format("{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                    if (key != null) pro.SetValue(objValue, httpContext.Request.Query[key][0].ToType(pro.PropertyType));
                }
                return objValue;
            }
        }
        public static object GetObjectValueByForm(this HttpContext httpContext, Type objType, string name)
        {
            FieldUploadFileAttribute fieldFile = null;
            IReadOnlyList<IFormFile> fileValues = null;
            IFormFileCollection files = httpContext.Request.Form.Files;
            if (objType.IsArray)
            {
                var typeOfElementOnObject = objType.GetElementType();

                var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}[]", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    return null;
                var len = httpContext.Request.Form[keys[0]].Count;
                var objValues = Array.CreateInstance(typeOfElementOnObject, len);
                if (!typeOfElementOnObject.IsValueType())
                {
                    var pros = typeOfElementOnObject.GetProperties();

                    for (var i = 0; i < len; i++)
                    {
                        var objValue = typeOfElementOnObject.CreateInstance();
                        foreach (var pro in pros)
                        {
                            fieldFile = null;
                            fileValues = null;
                            if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = files.GetListFiles(string.Format("{0}[].{1}", name, pro.Name))) != null)
                            {
                                pro.SetValue(objValue, httpContext.UploadFile(fileValues, fieldFile));
                            }
                            else
                            {
                                var key = keys.FirstOrDefault(p => p.EndsWith(string.Format("[].{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                                if (key != null) pro.SetValue(objValue, httpContext.Request.Form[key][i].ToType(pro.PropertyType));
                            }
                        }
                        objValues.SetValue(objValue, i);
                    }
                }
                else
                {
                    for (var i = 0; i < len; i++)
                    {
                        objValues.SetValue(httpContext.Request.Form[keys[0]][i].ToType(typeOfElementOnObject), i);
                    }
                }
                return objValues;
            }
            else if (objType.IsTypeFromInterface<IList>())
            {
                var objValues = objType.CreateInstance<IList>();
                var typeOfElementOnObject = objType.GetGenericArguments().Single();
                var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}[]", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    return null;
                var len = httpContext.Request.Form[keys[0]].Count;
                if (!typeOfElementOnObject.IsValueType())
                {
                    var pros = typeOfElementOnObject.GetProperties();

                    for (var i = 0; i < len; i++)
                    {
                        var objValue = typeOfElementOnObject.CreateInstance();
                        foreach (var pro in pros)
                        {
                            fieldFile = null;
                            fileValues = null;
                            if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = files.GetListFiles(string.Format("{0}[].{1}", name, pro.Name))) != null)
                            {
                                pro.SetValue(objValue, httpContext.UploadFile(fileValues, fieldFile));
                            }
                            else
                            {
                                var key = keys.FirstOrDefault(p => p.EndsWith(string.Format("[].{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                                if(key!=null) pro.SetValue(objValue, httpContext.Request.Form[key][i].ToType(pro.PropertyType));
                            }
                        }
                        objValues.Add(objValue);
                    }
                }
                else
                {
                    for (var i = 0; i < len; i++)
                    {
                        objValues.Add(httpContext.Request.Form[keys[0]][i].ToType(typeOfElementOnObject));
                    }
                }
                return objValues;
            }
            else if (objType.IsValueType())
            {
                fieldFile = null;
                fileValues = null;
                if ((fieldFile = objType.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = files.GetListFiles(name)) != null)
                {
                    return httpContext.UploadFile(fileValues, fieldFile);
                }
                var key = httpContext.Request.Form.Keys.FirstOrDefault(p => p.Equals(string.Format("{0}", name), StringComparison.OrdinalIgnoreCase));
                if (key == null)
                    return null;
                return httpContext.Request.Form[key][0].ToType(objType);
            }
            else
            {
                var pros = objType.GetProperties();
                var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}.", name), StringComparison.OrdinalIgnoreCase)).ToList();
                if (keys.Count == 0)
                    keys = httpContext.Request.Form.Keys.Where(p => p.IndexOf(".")<0 && p.IndexOf("[]") < 0).ToList();
                if (keys.Count == 0)
                    return null;
                var objValue = objType.CreateInstance();
                foreach (var pro in pros)
                {
                    fieldFile = null;
                    fileValues = null;
                    if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = files.GetListFiles(string.Format("{0}.{1}", name, pro.Name))) != null)
                    {
                        pro.SetValue(objValue, httpContext.UploadFile(fileValues, fieldFile));
                    }
                    else
                    {
                        var key = keys.FirstOrDefault(p => p.EndsWith(string.Format(".{0}", pro.Name), StringComparison.OrdinalIgnoreCase) || p.Equals(string.Format("{0}", pro.Name), StringComparison.OrdinalIgnoreCase));
                        if (key != null) pro.SetValue(objValue, httpContext.Request.Form[key][0].ToType(pro.PropertyType));
                    }
                }
                return objValue;
            }
        
        }
       
        public static void BindQueryTo( this HttpContext httpContext,object obj, string name = "") {
            if (name != "") name = name + ".";
            var objType = obj.GetType();
            var pros = objType.GetProperties();
            var keys = httpContext.Request.Form.Keys.Where(p => ((name != "" && p.StartsWith(name, StringComparison.OrdinalIgnoreCase)) || p.IndexOf(".") < 0) && p.IndexOf("[]") < 0).ToList();
            if (keys.Count == 0)
                return;
            foreach (var pro in pros)
            {               
                    var key = keys.FirstOrDefault(p => p.Equals(string.Format("{0}{1}", name, pro.Name), StringComparison.OrdinalIgnoreCase));
                    if (key != null) pro.SetValue(obj, httpContext.Request.Form[key][0].ToType(pro.PropertyType));
            }
        }
        public static void BindFormTo(this HttpContext httpContext, object obj,string name="")
        {
            FieldUploadFileAttribute fieldFile = null;
            IReadOnlyList<IFormFile> fileValues = null;
            var files=httpContext.Request.Form.Files;
            if (name != "") name = name +  ".";
           var objType = obj.GetType(); 
            var pros = objType.GetProperties();
            var  keys = httpContext.Request.Form.Keys.Where(p =>((name!=""&& p.StartsWith(name, StringComparison.OrdinalIgnoreCase))|| p.IndexOf(".") < 0 ) && p.IndexOf("[]") < 0).ToList();
            if (keys.Count == 0)
                return;
            foreach (var pro in pros)
            {
                fieldFile = null;
                fileValues = null;
                if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = files.GetListFiles(string.Format("{0}{1}", name, pro.Name))) != null)
                {
                    pro.SetValue(obj, httpContext.UploadFile(fileValues, fieldFile));
                }
                else
                {
                    var key = keys.FirstOrDefault(p => p.Equals(string.Format("{0}{1}", name, pro.Name), StringComparison.OrdinalIgnoreCase));
                    if (key != null) pro.SetValue(obj, httpContext.Request.Form[key][0].ToType(pro.PropertyType));
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
        public static string UploadFile(this HttpContext httpContext, string nameFile, FieldUploadFileAttribute fileInfo) {
            return httpContext.UploadFile(nameFile, fileInfo.Prefix, fileInfo.IsGenAutoNamFile, fileInfo.Separator, fileInfo.UseFullPath);
        }
        public static string UploadFile(this HttpContext httpContext,string nameFile, string Prefix="", bool IsGenAutoNamFile=false, string Separator=";", bool UseFullPath=true) {
            IReadOnlyList<IFormFile> fileValues = null;
            if ((fileValues = httpContext.Request.Form.Files.GetListFiles(nameFile)) != null)
            {
                return httpContext.UploadFile(fileValues, Prefix, IsGenAutoNamFile, Separator, UseFullPath);
            }
                return string.Empty;
        }
        public static string UploadFile(this HttpContext httpContext, IReadOnlyList<IFormFile> fileValues, FieldUploadFileAttribute fileInfo)
        {
            return httpContext.UploadFile(fileValues, fileInfo.Prefix, fileInfo.IsGenAutoNamFile, fileInfo.Separator, fileInfo.UseFullPath);
        }
        public static string UploadFile(this HttpContext httpContext, IReadOnlyList<IFormFile> fileValues, string Prefix = "", bool IsGenAutoNamFile = false, string Separator = ";", bool UseFullPath = true)
        {
            var pathUpload = Path.Combine("uploads", string.Format("{0:yyyy}/{0:MM}/{0:dd}", DateTime.Now));
            if (!Directory.Exists(pathUpload.MapWebRootPath()))
                Directory.CreateDirectory(pathUpload.MapWebRootPath());

            if (fileValues.Count == 1)
            {
                var valueFile = fileValues[0];
                if (valueFile.Length > 0)
                {
                    var nameFile = Path.GetFileNameWithoutExtension(valueFile.FileName);
                    var extensionFile = Path.GetExtension(valueFile.FileName);
                    if (IsGenAutoNamFile)
                        nameFile = Guid.NewGuid().ToString();
                    var filePath = Path.Combine(pathUpload, string.Format("{0}.{1}",nameFile,extensionFile));
                    using (var fileStream = new FileStream(filePath.MapWebRootPath(), FileMode.Create))
                    {
                        valueFile.OpenReadStream().CopyTo(fileStream);
                    }
                    if (UseFullPath)
                        return filePath;
                    else
                        return Path.GetFileName(filePath);
                }
            }
            else
            {
                var proValue = string.Empty;
                foreach (var valueFile in fileValues)
                {
                    if (valueFile.Length > 0)
                    {
                        var nameFile = Path.GetFileNameWithoutExtension(valueFile.FileName);
                        var extensionFile = Path.GetExtension(valueFile.FileName);
                        if (IsGenAutoNamFile)
                            nameFile = Guid.NewGuid().ToString();
                        var filePath = Path.Combine(pathUpload, string.Format("{0}.{1}", nameFile, extensionFile));
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            valueFile.OpenReadStream().CopyTo(fileStream);
                        }
                        if (UseFullPath)
                            proValue += filePath + Separator;
                        else
                            proValue += Path.GetFileName(filePath) + Separator;
                    }
                }
                return proValue;
            }
            return string.Empty;
        }
        public static IReadOnlyList<IFormFile> GetListFiles(this IFormFileCollection files, string name) {
            return files.Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static bool IsSubdomain(this HttpContext httpContext)
        {
            return httpContext?.Request.Host.Host.IsSubdomain()??false;
        }
        public static bool IsSubdomain(this string host)
        {
            return Regex.IsMatch(host, @"^[A-Za-z\d]+\.(?:[A-Za-z\d]+\.[A-Za-z\d]+|localhost)$");
        }
        public static string UrlCurrent(this HttpContext httpContext)
        {
            return (string)httpContext.Items[AZWebConstant.KeyUrlCurrent];
        }
        
    }
}
