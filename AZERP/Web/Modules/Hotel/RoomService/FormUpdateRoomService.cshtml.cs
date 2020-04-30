using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.RoomService
{
    public class FormUpdateRoomService : UpdateModule<AZERP.Data.Entities.RoomService, RoomServiceModel>
    {
        public FormUpdateRoomService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Dịch vụ phòng";
        }

    }
}
