using AZERP.Data.Entities;
using AZWeb.Extensions;
using AZWeb.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AZERP
{
    public class Startup: AZWeb.Utilities.IStartup
    {
        public string AssemblyName { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            AZCoreWeb.env = env;
            this.AssemblyName = "AZERP";
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMySQL("server=127.0.0.1;database=azcore;uid=root;pwd=;CharSet=utf8;");
            services.AddAZCore(this);
            
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
    }
}
