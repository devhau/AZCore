using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Common.Tenant
{
    public class FormUpdateTenant : UpdateModule<TenantService, TenantModel>
    {
        public FormUpdateTenant(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Đối tác";
        }

    }
}
