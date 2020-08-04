using AZCore.Database.SQL;
using AZCore.Extensions;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Admin.Tenant
{
    public class FormTenant : PageManage<TenantService,TenantModel, UpdateTenant>
    {
        public FormTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Danh sách tài khoản";
        }
        protected override void AddWhere(QuerySQL Q)
        {
          
        }
        protected override void AddQuerySQL(QuerySQL Q)
        {
            Q.SetColumn<TenantModel>(p=>p.GetColumn("*"));
          
        }
    }
}
