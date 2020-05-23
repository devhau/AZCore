using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Renter
{
    public class FormUpdateRenter : UpdateModule<RenterService, RenterModel>
    {
        public FormUpdateRenter(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Người Thuê Trọ";
        }

    }
}
