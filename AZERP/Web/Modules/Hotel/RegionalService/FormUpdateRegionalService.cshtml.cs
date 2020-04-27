using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.RegionalService
{
    public class FormUpdateRegionalService : UpdateModule<AZERP.Data.Entities.RegionalService, RegionalServiceModel>
    {
        public FormUpdateRegionalService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Dịch vụ khu vực";
        }

    }
}
