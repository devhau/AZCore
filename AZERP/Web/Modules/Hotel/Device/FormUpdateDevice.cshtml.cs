using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Device
{
    public class FormUpdateDevice : UpdateModule<DeviceService, DeviceModel>
    {
        public FormUpdateDevice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thiết bị";
        }

    }
}
