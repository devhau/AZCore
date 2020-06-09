using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.HotelDevice
{
    public class FormUpdateHotelDevice : UpdateModule<HotelDeviceService, HotelDeviceModel>
    {
        public FormUpdateHotelDevice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thiết bị phòng";
        }

    }
}
