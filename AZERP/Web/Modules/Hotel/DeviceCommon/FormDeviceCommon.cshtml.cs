using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.DeviceCommon
{
    [TableColumn(Title = "Mã Thiết Bị Chung", FieldName = "DeviceCommonCode", DataType = typeof(HotelService), Width = 150)]
    [TableColumn(Title = "Tên Thiết Bị Chung", FieldName = "DeviceName", Width = 150)]
    [TableColumn(Title = "Ghi Chú", FieldName = "Note")]

    public class FormDeviceCommon : ManageModule<DeviceCommonService, DeviceCommonModel, FormUpdateDeviceCommon>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã Thiết Bị Chung
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceCommonCode { get; set; }
        /// <summary>
        /// Tên Thiết Bị Chung
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceName { get; set; }
        #endregion

        public FormDeviceCommon(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh Sách Thiết Bị Chung";
        }
    }
}
