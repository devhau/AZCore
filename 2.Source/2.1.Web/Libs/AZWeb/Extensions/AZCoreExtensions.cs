using AZCore.Database;
using AZCore.Domain;
using AZCore.Extensions;
using AZCore.Identity;
using AZCore.Utility.Xml;
using AZWeb.Configs;
using AZWeb.Module;
using AZWeb.Module.Middleware;
using AZWeb.Module.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Linq;
using IStartupAZ = AZWeb.Utilities.IStartup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AZWeb.Extensions
{
    public static class AZCoreExtensions
    {
        internal static string key = "123456789@abcxyz";
        internal static IStartupAZ startup;
        public static void AddMySQL(this IServiceCollection services,string connectString="") {
            services.AddScoped<IDbConnection>((_) => new MySql.Data.MySqlClient.MySqlConnection(connectString));
        }
        public static void AddAZCore(this IServiceCollection services, IStartupAZ startup)
        {
            AZCoreExtensions.startup = startup;
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
            services.AddAuthentication(options =>
                                        {
                                            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                                            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                                            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                                        }).AddJwtBearer(x =>
                                        {
                                            x.RequireHttpsMetadata = false;
                                            x.SaveToken = true;
                                            x.TokenValidationParameters = new TokenValidationParameters
                                            {
                                                ValidateIssuerSigningKey = true,
                                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                                                ValidateIssuer = false,
                                                ValidateAudience = false
                                            };
                                            x.Events = new JwtBearerEvents
                                            {
                                                OnMessageReceived = context =>
                                                {
                                                    var accessToken = context.Request.Query["access_token"];

                                                    // If the request is for our hub...
                                                    var path = context.HttpContext.Request.Path;
                                                    if (!string.IsNullOrEmpty(accessToken) &&
                                                        (path.StartsWithSegments("/azhub")))
                                                    {
                                                        // Read the token out of the query string
                                                        context.Token = accessToken;
                                                    }
                                                    return Task.CompletedTask;
                                                }
                                            };
                                        }).AddIdentityCookies();
            //.AddIdentityCookies()
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddSingleton<IPagesConfig>((p)=> ReadConfig<PagesConfig>.Load(null, (t) => string.Format("{0}/{1}", p.GetRequiredService<IWebHostEnvironment>().ContentRootPath,t)));
            services.AddSingleton<ISecurityStampValidator, AZSecurityStampValidator>();
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
                if (item.IsTypeFromInterface<IGetGenCodeService>())
                {
                    services.AddTransient(typeof(IGetGenCodeService), item);
                }
                if (item.IsTypeFromInterface<ITenantService>())
                {
                    services.AddTransient(typeof(ITenantService), item);
                }
            }
            // Add EntityTransaction
            services.AddScoped(typeof(EntityTransaction));
        }
        public static void UseAZCore(this IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication(); 
            app.UseMiddleware<ModuleMiddleware>();

        }
        public static void UseSignalRAZCore(this IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                foreach (var typeHubg in startup.GetType().Assembly.GetTypeFromInterface<IAZHub>())
                    typeHubg.CreateInstance<HubBase>().MapRouter(routes);
            });
        }
        //params string[] paths
        public static string MapWebRootPath(this string path) {
           return Path.Combine(ModuleRender._hostingEnvironment.WebRootPath, path);

        }
        public static string MapWebRootPath(this object obj, params string[] paths)
        {
            return Path.Combine(paths).MapWebRootPath();
        }
        public static string MapContentRootPath(this string path)
        {
            return Path.Combine(ModuleRender._hostingEnvironment.ContentRootPath, path);

        }
        public static string MapContentRootPath(this object obj, params string[] paths)
        {
            return Path.Combine(paths).MapContentRootPath();
        }
    }
}
