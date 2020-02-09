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

namespace AZCore.Web.Extensions
{
    public static class HttpContextExtensions
    {
        public static string RenderToHtml(this HttpContext httpContext,string path,string viewName, object model) {

            var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
            var _razorViewEngine = httpContext.RequestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            var _tempDataProvider= httpContext.RequestServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;
            
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
    }
}
