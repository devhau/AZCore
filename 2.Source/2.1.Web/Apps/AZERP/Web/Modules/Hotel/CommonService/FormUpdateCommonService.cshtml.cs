using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.CommonService
{
    public class FormUpdateCommonService : UpdateModule<AZERP.Data.Entities.CommonService, CommonServiceModel>
    {
        public FormUpdateCommonService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Dịch vụ chung";
        }

    }
}
