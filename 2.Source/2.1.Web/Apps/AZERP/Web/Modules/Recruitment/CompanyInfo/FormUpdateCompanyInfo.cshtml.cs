using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.CompanyInfo
{
    public class FormUpdateCompanyInfo : UpdateModule<CompanyInfoService, CompanyInfoModel>
    {
        public FormUpdateCompanyInfo(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Cộng tác viên";
        }

    }
}
