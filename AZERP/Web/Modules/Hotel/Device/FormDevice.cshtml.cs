using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Device
{
    [TableColumn(Title = "Mã Phòng ", FieldName = "HotelID", DataType = typeof(HotelService), Width = 100)]
    [TableColumn(Title = "Thiết Bị ", FieldName = "DeviceID", DataType = typeof(DeviceCommonService), Width = 100)]
    [TableColumn(Title = "Ghi Chú", FieldName = "Note")]

    public class FormDevice : ManageModule<DeviceService, DeviceModel, FormUpdateDevice>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã Phòng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? HotelID { get; set; }
        /// <summary>
        /// Tên thiết bị
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string DeviceName { get; set; }
        #endregion

        public FormDevice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh Sách Thiết Bị";
        }
    }
}
