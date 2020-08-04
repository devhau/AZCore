using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Tenant
{
    public class UpdateTenant : PageUpdate<TenantService,TenantModel>
    {
        public UpdateTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            
        }
        protected override void AfterGet()
        {
            if (this.IsNew)
            {
                this.Title = "Thêm mới đối tác mới";
            }
            else
                this.Title = "Cập nhật đối tác: " + this.Data.Name;
        }
    }
}
