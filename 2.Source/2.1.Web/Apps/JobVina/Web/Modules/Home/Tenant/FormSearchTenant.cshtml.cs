using AZCore.Database.SQL;
using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Home.Tenant
{
    public class FormSearchTenant : PageSearch<TenantService, TenantModel>
    {
        [BindQuery(FromName = "TextSearch")]
        public string TextSearch { get; set; }
        public FormSearchTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void AddWhere(QuerySQL Q)
        {
            Q.AddWhere<TenantModel>(p => "Name", TextSearch,AZCore.Database.Enums.OperatorSQL.Contains);
            base.AddWhere(Q);
        }
        public override IView Get()
        {
            if (TextSearch.IsNullOrEmpty())
            {
                this.Title = "Tìm đối tác cung ứng lao động uy tín";
            }
            else
            {
                this.Title = "Tìm đối tác cung ứng:" + TextSearch;
            }
            return base.Get();
        }
    }
}
