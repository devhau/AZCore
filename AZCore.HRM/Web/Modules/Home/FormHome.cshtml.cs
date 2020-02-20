using AZCore.Web.Common.Module;
using Microsoft.AspNetCore.Http;

namespace AZCore.HRM.Web.Modules.Home
{
    public class FormHome:ModuleBase
    {
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public string id { get; set; }
        public object Get(){
           return View();
        }
    }
}
