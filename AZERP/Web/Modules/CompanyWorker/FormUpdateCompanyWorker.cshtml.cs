using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.CompanyWorker
{
    public class FormUpdateCompanyWorker : UpdateModule<CompanyWorkerService, CompanyWorkerModel>
    {
        public FormUpdateCompanyWorker(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý công ty thuê công nhân";
        }

    }
}
