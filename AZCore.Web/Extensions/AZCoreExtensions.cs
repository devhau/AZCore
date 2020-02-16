using AZCore.Utility.Xml;
using AZCore.Web.Common;
using AZCore.Web.Common.Module;
using AZCore.Web.Configs;
using AZCore.Web.Middleware;
using AZCore.Web.Utilities;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace AZCore.Web.Extensions
{
    public static class AZCoreExtensions
    {
        public static void UseAZCore(this IApplicationBuilder app) {
            app.UseMiddleware<AZCoreRouterMiddleware>();
        }
        public static void AddAZCore(this IServiceCollection services, IStartup startup)
        {
            services.AddRazorPages();

            if (string.IsNullOrEmpty(startup.AssemblyName)) {
                startup.AssemblyName = startup.GetType().Assembly.GetName().Name; ;
            }
            var PagesConfig = ReadConfig<PagesConfig>.Load(null, (t) => t.MapPath());
            services.AddHttpContextAccessor();
            services.AddSingleton<IPagesConfig>(PagesConfig);
            services.AddSingleton<IStartup>(startup);
            services.AddSingleton<ModulePortal>((t1) => new ModulePortal(t1.GetRequiredService<IStartup>(), t1.GetRequiredService<IHttpContextAccessor>(), t1.GetRequiredService<IPagesConfig>())) ; 
            // services.AddSingleton();
        }
        public static IObject CreateInstance<IObject>(this Type obj) where IObject:class => Activator.CreateInstance(obj) as IObject;
        public static IObject CreateInstance<IObject>(this string strObj,string strAssembly) where IObject : class => Activator.CreateInstance(strAssembly,strObj) as IObject;
        public static IModuleResult LoadModuleFromUrl(this AZPage page)
        {
            return page.HttpContext.RequestServices.GetRequiredService<ModulePortal>().GetResult();
        }
        public static string LoadThemeFromUrl(this AZPage page)
        {
            return page.HttpContext.RequestServices.GetRequiredService<ModulePortal>().GetTheme().GetHtml();
        }
        public static string LoadTextFile(this string path)
        {
            var file= AZCoreWeb.env.ContentRootFileProvider.GetFileInfo(path);

            if (file.Exists) {
                return File.ReadAllText(file.PhysicalPath);
            }
            return "";
        }
        public static string MapPath(this string path) {
           return AZCoreWeb.env.ContentRootFileProvider.GetFileInfo(path).PhysicalPath;
        }
        public static HtmlDocument LoadHtml(this string content) {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            return htmlDoc;
        } 

    }
}
