using AZCore.Web.Common;
using AZCore.Web.Common.Module;
using AZCore.Web.Middleware;
using AZCore.Web.Rule;
using AZCore.Web.Transformer;
using AZCore.Web.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AZCore.Web.Extensions
{
    public static class AZCoreExtensions
    {
        public static void UseAZCore(this IApplicationBuilder app) {
            var rewrite = new RewriteOptions();
            rewrite.Add(new AZRewriteRule());

            app.UseRewriter(rewrite);

            app.UseMiddleware<AZCoreRouterMiddleware>();
        }
        public static void AddAZCore(this IServiceCollection services)
        {
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                options.Conventions.Add(new PageRouteTransformerConvention(new HyphenateRouteParameterTransformer()));
            });
        }
        public static IObject CreateInstance<IObject>(this Type obj) where IObject:class => Activator.CreateInstance(obj) as IObject;
        public static IObject CreateInstance<IObject>(this string strObj,string strAssembly) where IObject : class => Activator.CreateInstance(strAssembly,strObj) as IObject;
        public static IModuleResult LoadModuleFromUrl(this AZPage page)
        {
            return new AZCoreWeb(page.HttpContext).GetResult();
        }
    }
}
