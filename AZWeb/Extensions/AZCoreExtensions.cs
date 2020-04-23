using AZCore.Database;
using AZCore.Domain;
using AZCore.Extensions;
using AZCore.Identity;
using AZCore.Utility.Xml;
using AZWeb.Configs;
using AZWeb.Module.Middleware;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Linq;
using IStartupAZ = AZWeb.Utilities.IStartup;

namespace AZWeb.Extensions
{
    public static class AZCoreExtensions
    {
        public static void AddMySQL(this IServiceCollection services,string connectString="") {
            services.AddScoped<IDbConnection>((_) => new MySql.Data.MySqlClient.MySqlConnection(connectString));
        }
        public static void AddAZCore(this IServiceCollection services, IStartupAZ startup)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60*60*24);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddSingleton<IPagesConfig>((p)=> ReadConfig<PagesConfig>.Load(null, (t) => string.Format("{0}/{1}", p.GetRequiredService<IWebHostEnvironment>().ContentRootPath,t)));
            services.AddSingleton<IStartupAZ>(startup);
            //IHostedService
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
                if (item.IsTypeFromInterface<IHostedService>())
                    services.AddTransient(typeof(IHostedService), item);
                if (item.IsTypeFromInterface<IPermissionService>())
                {
                    services.AddTransient(typeof(IPermissionService), item);

                }
            }
            // Add EntityTransaction
            services.AddScoped(typeof(EntityTransaction));
        }
        public static void UseAZCore(this IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMiddleware<ModuleMiddleware>();

        }
        public static HtmlDocument LoadHtml(this string content) {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            return htmlDoc;
        } 
    }
}
