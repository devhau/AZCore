using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.TypeOfHotel
{
    public class FormUpdateTypeOfHotel : UpdateModule<TypeOfHotelService, TypeOfHotelModel>
    {
        public FormUpdateTypeOfHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Loại phòng trọ";
        }

    }
}
