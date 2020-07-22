using AZWeb.Middleware;
using AZWeb.Module;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobVina.Middleware
{
    /// <summary>
    /// Process request Router for Module
    /// </summary>
    public class WebRouterMiddleware : DoMiddlewareBase
    {
        public WebRouterMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override async Task<bool> DoMiddleware(HttpContext httpContext)
        {
            if (httpContext.Items[ModuleWebInfo.Key] == null)
            {
                var urlPath = (httpContext.Request.Path);
                if (urlPath == "/")
                {
                    httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                    {
                        ModulePath = "Web.Modules.Home.FormHome",
                        MethodName = "Get"
                    };
                }
                else if (urlPath.Value.EndsWith(".az"))
                {
                    if (ModuleWebInfo.Rewrites != null && ModuleWebInfo.Rewrites.Count > 0)
                    {
                        foreach (var item in ModuleWebInfo.Rewrites)
                        {
                            var RegexPath = new Regex(string.Format("/{0}", item.Key));
                            if (RegexPath.IsMatch(urlPath))
                            {
                                var pathReal = RegexPath.Replace(urlPath, item.Value);
                                foreach (var key in httpContext.Request.Query.Keys)
                                {
                                    pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
                                }
                                var query = QueryHelpers.ParseQuery(pathReal);
                                if (!query.ContainsKey("m") || string.IsNullOrEmpty(query["m"].ToString())) return default;
                                string moduleName = query["m"].ToString();
                                string viewName = moduleName;
                                if (query.ContainsKey("v") && !string.IsNullOrEmpty(query["v"].ToString()))
                                    viewName = query["v"].ToString();
                                string gm = "";
                                if (query.ContainsKey("gm") && !string.IsNullOrEmpty(query["gm"].ToString()))
                                    gm = "." + query["gm"].ToString();
                                string ModuleStr = string.Format("Web.Modules{2}.{0}.Form{1}", moduleName, viewName, gm);
                                string methodName = httpContext.Request.Method;
                                if (query.ContainsKey("h") && !string.IsNullOrEmpty(query["h"].ToString()))
                                    methodName = string.Format("{0}{1}", methodName, query["h"].ToString());
                                httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                                {
                                    ModulePath = ModuleStr,
                                    MethodName = methodName
                                };
                                return false;
                            }
                        }
                    }
                    var ModulePath = urlPath.Value.Substring(0, urlPath.Value.LastIndexOf(".")).Trim('/').Replace("-", "");
                    if (httpContext.Request.Query["h"].Count > 0)
                    {
                        ModulePath = ModulePath + "/" + httpContext.Request.Query["h"];
                    }
                    var ModulePaths = ModulePath.Split('/');
                    string path1 = ModulePaths.Length > 1 ? ModulePaths[^1] : string.Empty;// ~ Length-1
                    string path2 = ModulePaths.Length > 1 ? ModulePaths[^2] : ModulePaths[^1];// ~ Length-2
                   
                    ModulePath = "Web.Modules";
                    for (int i = 0; i < ModulePaths.Length - 2; i++)
                    {
                        ModulePath = ModulePath + "." + ModulePaths[i];
                    }
                    if (ModuleWebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.Form{2}", ModulePath, path2, path1).ToLower()))
                    {
                        httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                        {
                            ModulePath = string.Format("{0}.{1}.Form{2}", ModulePath, path2, path1),
                            MethodName = string.Format("{0}", httpContext.Request.Method),
                            IsAuto = true
                        };
                    }
                    else if (ModuleWebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.{2}.Form{2}", ModulePath, path2, path1).ToLower()))
                    {
                        httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                        {
                            ModulePath = string.Format("{0}.{1}.{2}.Form{2}", ModulePath, path2, path1),
                            MethodName = string.Format("{0}", httpContext.Request.Method),
                            IsAuto = true
                        };
                    }
                    else if (ModuleWebInfo.dicModule.ContainsKey(string.Format("{0}.Form{1}", ModulePath, path2).ToLower()))
                    {
                        httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                        {
                            ModulePath = string.Format("{0}.Form{1}", ModulePath, path2),
                            MethodName = string.Format("{0}{1}", httpContext.Request.Method, path1),
                            IsAuto = true
                        };
                    }
                    else if (ModuleWebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.Form{1}", ModulePath, path2).ToLower()))
                    {
                        httpContext.Items[ModuleWebInfo.Key] = new ModuleWebInfo()
                        {
                            ModulePath = string.Format("{0}.{1}.Form{1}", ModulePath, path2),
                            MethodName = string.Format("{0}{1}", httpContext.Request.Method, path1),
                            IsAuto = true
                        };
                    }

                }
            }
            await Task.CompletedTask;
            return false;
        }
    }
}
