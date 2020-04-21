using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Area
{
    public class FormUpdateArea : UpdateModule<AreaService, AreaModel>
    {
        public FormUpdateArea(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Khu vực";
        }

    }
}
