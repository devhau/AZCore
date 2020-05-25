using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Building
{
    public class FormUpdateBuilding : UpdateModule<BuildingService, BuildingModel>
    {
        public FormUpdateBuilding(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Cộng tác viên";
        }

    }
}
