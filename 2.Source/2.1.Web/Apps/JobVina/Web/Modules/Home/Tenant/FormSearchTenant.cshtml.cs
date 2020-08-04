using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home.Tenant
{
    public class FormSearchTenant : PageHome
    {
        [BindQuery]
        public string TextSearch { get; set; }
        public FormSearchTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IView Get()
        {
            if (TextSearch.IsNullOrEmpty())
            {
                this.Title = "Tìm đối tác cung ứng lao động uy tín";
            }
            else
            {
                this.Title = "Tìm đối tác cung ứng:" + TextSearch;
            }
            return View();
        }
    }
}
