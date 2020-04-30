﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections;
using AZCore.Extensions;
using AZWeb.Module.Attributes;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AZWeb.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="obj"></param>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="obj"></param>
        public static void BindFormAttributeTo(this HttpContext httpContext, object obj)
        {
            if (!httpContext.Request.HasFormContentType) return;
            var objType = obj.GetType();
            var file = httpContext.Request.Form.Files;
            foreach (var pro in objType.GetPropertyByAttribute<BindFormAttribute>())
            {
                FieldUploadFileAttribute fieldFile = null;
                IReadOnlyList<IFormFile> fileValues = null;
                if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = file.GetFiles(pro.Name)) != null)
                {
                    pro.SetValue(obj, httpContext.UploadFile(fileValues, fieldFile));
                    continue;
                }
                else if (pro.PropertyType.IsTypeFromInterface<IList>())
                {
                    if (httpContext.Request.Form.Keys.Any(p => p.StartsWith(string.Format("{0}[].", pro.Name), StringComparison.OrdinalIgnoreCase)))
                    {
                        var keys = httpContext.Request.Form.Keys.Where(p => p.StartsWith(string.Format("{0}[]", pro.Name), StringComparison.OrdinalIgnoreCase)).ToList();
                        var objectValues = (IList)pro.PropertyType.CreateInstance();
                        var len = httpContext.Request.Form[keys[0]].Count;
                        var typeObject = pro.PropertyType.GetGenericArguments().Single();
                        for (var index = 0; index < len; index++)
                        {
                            if (typeObject.IsClass)
                            {
                                var objectValue = typeObject.CreateInstance();
                                foreach (var pro1 in typeObject.GetProperties())
                                {
                                    fieldFile = null;
                                    fileValues = null;
                                    if ((fieldFile = pro1.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = file.GetFiles(string.Format("{0}[].{1}", pro.Name, pro1.Name))) != null)
                                    {
                                        pro1.SetValue(objectValue, httpContext.UploadFile(fileValues, fieldFile));
                                    }
                                    else if (httpContext.Request.Form.Keys.Any(p => p == string.Format("{0}[].{1}", pro.Name, pro1.Name)))
                                    {
                                        httpContext.SetValuePropertion(objectValue, pro, pro1, true, index);
                                    }
                                }

                                objectValues.Add(objectValue);
                            }
                            else
                            {
                                if (typeObject.IsArray)
                                {
                                    objectValues.Add(httpContext.Request.Form[string.Format("{0}[]", pro.Name)][index].Split(',').Select(p => p.ToType(typeObject.GetElementType())).ToArray());
                                }
                                else
                                {
                                    objectValues.Add(httpContext.Request.Form[string.Format("{0}[]", pro.Name)][index].ToType(typeObject));
                                }
                                // var objectValue = null;
                            }                         
                        }
                        pro.SetValue(obj, objectValues);
                    }
                    continue;
                }
                else if (pro.PropertyType.IsGenericType)
                {
                    if (httpContext.Request.Form.Keys.Any(p => p.StartsWith(string.Format("{0}.", pro.Name), StringComparison.OrdinalIgnoreCase)))
                    {

                        var objectValue = pro.PropertyType.CreateInstance();
                        foreach (var pro1 in pro.PropertyType.GetProperties())
                        {
                            fieldFile = null;
                            fileValues = null;
                            if ((fieldFile = pro1.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = file.GetFiles(string.Format("{0}.{1}", pro.Name, pro1.Name))) != null)
                            {
                                pro1.SetValue(objectValue, httpContext.UploadFile(fileValues, fieldFile));
                                continue;
                            }
                            else if (httpContext.Request.Form.Keys.Any(p => p == string.Format("{0}.{1}", pro.Name, pro1.Name)))
                            {

                                httpContext.SetValuePropertion(objectValue, pro, pro1);

                            }

                        }
                        pro.SetValue(obj, objectValue);
                    }

                    continue;
                }
                else if (httpContext.Request.Form.Keys.Contains(pro.Name))
                {
                    httpContext.SetValuePropertion(obj, pro);
                }


            }
        }
        public static void SetValuePropertion(this HttpContext httpContext, object obj, PropertyInfo pro, PropertyInfo pro1,bool IsList=false,int index=0)
        {
            var proName = string.Format("{0}.{1}", pro.Name, pro1.Name);
            if(IsList)
                proName = string.Format("{0}[].{1}", pro.Name, pro1.Name);
            if (pro1.PropertyType.IsArray)
            {
                pro1.SetValue(obj, httpContext.Request.Form[proName][index].Split(',').Select(p => p.ToType(pro1.PropertyType.GetElementType())).ToArray());
            }
            else
            {
                pro1.SetValue(obj, httpContext.Request.Form[proName][index].ToType(pro1.PropertyType));
            }
        }
        public static void SetValuePropertion(this HttpContext httpContext, object obj, PropertyInfo pro, bool IsList = false, int index = 0)
        {
            var proName = string.Format("{0}", pro.Name);
            if (IsList)
                proName = string.Format("{0}[]", pro.Name);
            if (pro.PropertyType.IsArray)
                {
                    pro.SetValue(obj, httpContext.Request.Form[proName][index].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                }
                else
                {
                    pro.SetValue(obj, httpContext.Request.Form[proName][index].ToType(pro.PropertyType));
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
            var uploads = "uploads";
            var file = httpContext.Request.Form.Files;
            var objType = obj.GetType();
            foreach (var pro in objType.GetProperties()) {
                if (pro.CanWrite)
                {
                    FieldUploadFileAttribute fieldFile = null;
                    IReadOnlyList<IFormFile> fileValues = null;
                    if ((fieldFile = pro.GetAttribute<FieldUploadFileAttribute>()) != null && (fileValues = file.GetFiles(pro.Name)) != null)
                    {
                        if (fileValues.Count == 1)
                        {
                            var valueFile = fileValues[0];
                            if (valueFile.Length > 0)
                            {
                                var filePath = Path.Combine(uploads, valueFile.FileName);
                                using (var fileStream = new FileStream(filePath.MapWebRootPath(), FileMode.Create))
                                {
                                    valueFile.OpenReadStream().CopyTo(fileStream);
                                }
                                pro.SetValue(obj, filePath);
                            }
                        }
                        else
                        {
                            var proValue = "";
                            foreach (var valueFile in fileValues)
                            {
                                if (valueFile.Length > 0)
                                {
                                    var filePath = Path.Combine(uploads, valueFile.FileName);
                                    using (var fileStream = new FileStream(filePath.MapWebRootPath(), FileMode.Create))
                                    {
                                        valueFile.OpenReadStream().CopyTo(fileStream);
                                    }
                                    proValue += filePath + fieldFile.Separator;
                                }
                            }
                            pro.SetValue(obj, proValue);
                        }
                    }
                    else if(httpContext.Request.Form.ContainsKey(pro.Name))
                    {
                        if (pro.PropertyType.IsArray)
                        {
                            pro.SetValue(obj, httpContext.Request.Form[pro.Name][0].Split(',').Select(p => p.ToType(pro.PropertyType.GetElementType())).ToArray());
                        }
                        else
                        {
                            pro.SetValue(obj, httpContext.Request.Form[pro.Name][0].ToType(pro.PropertyType));
                        }
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
        public static string UploadFile(this HttpContext httpContext, string nameFile, FieldUploadFileAttribute fileInfo) {
            return httpContext.UploadFile(nameFile, fileInfo.Prefix, fileInfo.IsGenAutoNamFile, fileInfo.Separator, fileInfo.UseFullPath);
        }
        public static string UploadFile(this HttpContext httpContext,string nameFile, string Prefix="", bool IsGenAutoNamFile=false, string Separator=";", bool UseFullPath=true) {
            IReadOnlyList<IFormFile> fileValues = null;
            if ((fileValues = httpContext.Request.Form.Files.GetFiles(nameFile)) != null)
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
                    var filePath = Path.Combine(pathUpload, valueFile.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        valueFile.OpenReadStream().CopyTo(fileStream);
                    }
                    return filePath;
                }
            }
            else
            {
                var proValue = string.Empty;
                foreach (var valueFile in fileValues)
                {
                    if (valueFile.Length > 0)
                    {
                        var filePath = Path.Combine(pathUpload, valueFile.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            valueFile.OpenReadStream().CopyTo(fileStream);
                        }
                        proValue += filePath + Separator;
                    }
                }
                return proValue;
            }
            return string.Empty;
        }
    }
}
