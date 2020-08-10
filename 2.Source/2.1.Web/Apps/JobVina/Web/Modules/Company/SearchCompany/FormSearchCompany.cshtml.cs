using AZCore.Database.SQL;
using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using JobVina.Data.Entities.Company;
using Microsoft.AspNetCore.Http;

namespace JobVina.Web.Modules.Company.SearchCompany
{
    public class FormSearchCompany : PageSearch<TenantService, CompanyInfoModel>
    {
        [BindQuery(FromName = "TextSearch")]
        public string TextSearch { get; set; }
        public FormSearchCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void AddWhere(QuerySQL Q)
        {
            Q.AddWhere<CompanyInfoModel>(p => "Name", TextSearch,AZCore.Database.Enums.OperatorSQL.Contains);
            base.AddWhere(Q);
        }
        public override IView Get()
        {
            if (TextSearch.IsNullOrEmpty())
            {
                this.Title = "Tìm kiếm công ty";
            }
            else
            {
                this.Title = "Tìm kiếm công ty:" + TextSearch;
            }
            return base.Get();
        }
    }
}
