using AZERP.Data.Entities;
using AZERP.Data.Entities.Hotel;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Hotel
{
    public class FormUpdateHotel : UpdateModule<HotelService, HotelModel>
    {
        public FormUpdateHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Phòng trọ";
        }

    }
}
