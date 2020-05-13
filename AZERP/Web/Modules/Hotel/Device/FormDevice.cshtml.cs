using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Device
{
    [TableColumn(Title = "Mã thiết bị ", FieldName = "DeviceID", Width = 100)]
    [TableColumn(Title = "Tên thiết bị", FieldName = "DeviceName", Width = 130)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormDevice : ManageModule<DeviceService, DeviceModel, FormUpdateDevice>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceName { get; set; }
        #endregion

        public FormDevice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý thiết bị";
        }
    }
}
