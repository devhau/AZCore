using AZERP.Data.Entities;
using AZERP.Web.HostedService;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using AZCore.Extensions;
using AZWeb.Module.Common;

namespace AZERP
{
    public class Startup: AZWeb.Utilities.IStartup
    {
        private static Dictionary<String, Type> dicType = new Dictionary<string, Type>();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            this.GetType().Assembly.GetTypes().Where(p => p.FullName.Contains(".Web.")&&p.IsTypeFromInterface<IModule>()).Any(p =>
            {
                var indexWeb= p.FullName.IndexOf(".Web.");
                var key = p.FullName.Substring(indexWeb+1).ToLower().Trim();
                dicType[key] = p;
                return false;
            });
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMySQL(Configuration.GetConnectionString("Mysql"));
            services.AddAZCore(this); 
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            }); 
            //

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.Use(next =>
            {
                return async ctx =>
                {
                    ctx.RequestServices.GetRequiredService<DBCreateEntities>()?.CheckDatabase();
                    await next(ctx);
                };
            });
            app.UseAZCore();
          


        }

        public Type GetType(string type)
        {
            type = type.ToLower().Trim();
            if (dicType.ContainsKey(type)) return dicType[type];
            return null;
        }
    }
}
