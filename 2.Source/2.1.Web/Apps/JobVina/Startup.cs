using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZCore.Database;
using AZCore.Extensions;
using AZWeb.Extensions;
using AZWeb.Module;
using AZWeb.Module.Common;
using AZWeb.Module.Middleware;
using AZWeb.Module.Validator;
using JobVina.Data;
using JobVina.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace JobVina
{
    public class Startup
    {
        const string checkModule = ".Web"; 
        IConfiguration Configuration { get; }
        IWebHostEnvironment env;
        public Startup(
              IConfiguration configuration,
              IWebHostEnvironment env)
        {
            this.env = env;
            WebInfo.env = env;
            Configuration = configuration;

            using (StreamReader sr = new StreamReader(WebInfo.ReadStreamFromResource("JobVina/Configs/rewrite.configs")))
            {
                while (sr.Peek() >= 0)
                {
                    var row = sr.ReadLine();
                    if (!row.IsNullOrEmpty())
                    {
                        var paths = row.Split(" ");
                        if (paths.Length == 2)
                        {
                            if (!WebInfo.Rewrites.ContainsKey(paths[0]))
                            {
                                WebInfo.Rewrites[paths[0]] = paths[1];
                            }
                        }
                    }
                }
            }
            this.GetType().Assembly.GetTypes().Where(p => p.FullName.IndexOf(checkModule)>0 && p.IsTypeFromInterface<IModule>()).Any(p =>
            {
                var indexWeb = p.FullName.IndexOf(checkModule);
                var key = p.FullName.Substring(indexWeb + 1).ToLower().Trim();
                if(!WebInfo.dicModule.ContainsKey(key))
                    WebInfo.dicModule[key] = p;
                return false;
            });
        }

        const string key = "12345679@abcxyz";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
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
            services.AddMySQL(Configuration.GetConnectionString("Mysql"));

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(60 * 60 * 24);
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
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            }).AddIdentityCookies();

            services.AddRazorPages();
            services.AddHttpContextAccessor();

            services.AddSingleton<ISecurityStampValidator, AZSecurityStampValidator>();
            services.AddAZSerivce(typeof(Startup).Assembly);
            services.AddAZSerivce(typeof(DBCreateEntities).Assembly);
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseRouting();
            app.UseMiddleware<UrlCurrentMiddleware>();
            app.UseMiddleware<WebApiMiddleware>();
            app.UseMiddleware<WebRouterMiddleware>();
            app.UseMiddleware<ModuleWebMiddleware>();

            new DBCreateEntities( app.ApplicationServices.GetService(typeof(IDatabaseCore)) as IDatabaseCore, Configuration.GetValue<bool>("DropTable")).CheckEmptyAndCreateDatabase();
        }
    }
}
