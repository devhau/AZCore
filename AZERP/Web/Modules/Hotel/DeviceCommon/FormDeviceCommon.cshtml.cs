using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.DeviceCommon
{
    [TableColumn(Title = "Mã thiết bị", FieldName = "DeviceCommonCode", Width = 150)]
    [TableColumn(Title = "Tên thiết bị", FieldName = "DeviceName", Width = 150)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormDeviceCommon : ManageModule<DeviceCommonService, DeviceCommonModel, FormUpdateDeviceCommon>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã thiết bị
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceCommonCode { get; set; }
        /// <summary>
        /// Tên thiết bị
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceName { get; set; }
        #endregion

        public FormDeviceCommon(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách thiết bị";
        }
    }
}
