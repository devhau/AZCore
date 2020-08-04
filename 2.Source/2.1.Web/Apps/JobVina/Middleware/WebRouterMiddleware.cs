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
#if !DEBUG
            if (!httpContext.Request.Host.Host.Contains("jobvina.vn")) {
                httpContext.Response.Redirect("http://jobvina.vn/");
                return true;
            }
#endif
            if (httpContext.Items[WebInfo.Key] == null)
            {
                var urlPath = (httpContext.Request.Path);
                if (urlPath == "/")
                {
                    httpContext.Items[WebInfo.Key] = new WebInfo()
                    {
                        ModulePath = "Web.Modules.Home.FormHome",
                        MethodName = "Get"
                    };
                }
                else if (urlPath.Value.EndsWith(".az"))
                {
                    if (WebInfo.Rewrites != null && WebInfo.Rewrites.Count > 0)
                    {
                        foreach (var item in WebInfo.Rewrites)
                        {
                            var RegexPath = new Regex(string.Format("/{0}", item.Key));
                            if (RegexPath.IsMatch(urlPath))
                            {
                                var pathReal = RegexPath.Replace(urlPath, item.Value);
                                if (!pathReal.Contains(".az"))
                                {
                                    foreach (var key in httpContext.Request.Query.Keys)
                                    {
                                        pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
                                    }
                                    var query = QueryHelpers.ParseQuery(pathReal);
                                    httpContext.Request.QueryString = QueryString.Create(query);

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
                                    httpContext.Items[WebInfo.Key] = new WebInfo()
                                    {
                                        ModulePath = ModuleStr,
                                        MethodName = methodName
                                    };
                                    return false;
                                }
                                else {
                                    var index = pathReal.IndexOf("?");
                                    if (index > 0)
                                    {
                                        urlPath = httpContext.Request.Path = new PathString(pathReal.Substring(0, index));
                                        pathReal = pathReal.Substring(index + 1);
                                        foreach (var key in httpContext.Request.Query.Keys)
                                        {
                                            pathReal = string.Format("{0}&{1}={2}", pathReal, key, httpContext.Request.Query[key]);
                                        }
                                        httpContext.Request.QueryString = QueryString.Create(QueryHelpers.ParseQuery(pathReal));
                                    }
                                    else {
                                        urlPath = httpContext.Request.Path = new PathString(pathReal);
                                    }
                                    break;
                                }
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
                    if (WebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.Form{2}", ModulePath, path2, path1).ToLower()))
                    {
                        httpContext.Items[WebInfo.Key] = new WebInfo()
                        {
                            ModulePath = string.Format("{0}.{1}.Form{2}", ModulePath, path2, path1),
                            MethodName = string.Format("{0}", httpContext.Request.Method),
                            IsAuto = true
                        };
                    }
                    else if (WebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.{2}.Form{2}", ModulePath, path2, path1).ToLower()))
                    {
                        httpContext.Items[WebInfo.Key] = new WebInfo()
                        {
                            ModulePath = string.Format("{0}.{1}.{2}.Form{2}", ModulePath, path2, path1),
                            MethodName = string.Format("{0}", httpContext.Request.Method),
                            IsAuto = true
                        };
                    }
                    else if (WebInfo.dicModule.ContainsKey(string.Format("{0}.Form{1}", ModulePath, path2).ToLower()))
                    {
                        httpContext.Items[WebInfo.Key] = new WebInfo()
                        {
                            ModulePath = string.Format("{0}.Form{1}", ModulePath, path2),
                            MethodName = string.Format("{0}{1}", httpContext.Request.Method, path1),
                            IsAuto = true
                        };
                    }
                    else if (WebInfo.dicModule.ContainsKey(string.Format("{0}.{1}.Form{1}", ModulePath, path2).ToLower()))
                    {
                        httpContext.Items[WebInfo.Key] = new WebInfo()
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
