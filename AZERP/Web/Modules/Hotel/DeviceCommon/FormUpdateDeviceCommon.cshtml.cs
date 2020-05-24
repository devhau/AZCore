using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.DeviceCommon
{
    public class FormUpdateDeviceCommon : UpdateModule<DeviceCommonService, DeviceCommonModel>
    {
        public FormUpdateDeviceCommon(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thiết bị";
        }

    }
}
