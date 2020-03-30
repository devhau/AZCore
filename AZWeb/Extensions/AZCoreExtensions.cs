using AZCore.Domain;
using AZCore.Extensions;
using AZCore.Utility.Xml;
using AZWeb.Configs;
using AZWeb.Middleware;
using AZWeb.Utilities;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.IO;
using System.Linq;

namespace AZWeb.Extensions
{
    public static class AZCoreExtensions
    {
        public static void AddMySQL(this IServiceCollection services,string connectString="") {
            services.AddScoped<IDbConnection>((t) => new MySql.Data.MySqlClient.MySqlConnection(connectString));
        }
        public static void UseAZCore(this IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                app.UseMiddleware<AZWebMiddleware>();
            });
            //IDBCreate
        }
        public static void AddAZCore(this IServiceCollection services, IStartup startup)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages();
            var PagesConfig = ReadConfig<PagesConfig>.Load(null, (t) => t.MapPath());
            services.AddHttpContextAccessor();
            services.AddSingleton<IPagesConfig>(PagesConfig);
            services.AddSingleton<IStartup>(startup);
            foreach (var item in AppDomain.CurrentDomain.GetAssemblies().SelectMany(p => p.GetTypeFromInterface<IAZDomain>())) {
                if (item.IsTypeFromInterface<IAZTransient>()) {
                    services.AddTransient(item);
                }
                if (item.IsTypeFromInterface<IAZSingleton>())
                {
                    services.AddSingleton(item);
                }
                if (item.IsTypeFromInterface<IAZScoped>())
                {
                    services.AddScoped(item);
                }
            }
            
        }
        public static IObject CreateInstance<IObject>(this Type obj) where IObject:class => Activator.CreateInstance(obj) as IObject;
        public static IObject CreateInstance<IObject>(this string strObj,string strAssembly) where IObject : class => Activator.CreateInstance(strAssembly,strObj) as IObject;
       
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
