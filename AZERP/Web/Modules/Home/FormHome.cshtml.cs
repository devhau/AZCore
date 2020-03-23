using AZWeb.Common.Module;
using AZWeb.Common.Module.Attr;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Home
{
    [Auth]
    public class FormHome:PageModule
    {
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public string id { get; set; }
        public IView Get(){
           return View();
        }
    }
}
