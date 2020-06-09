using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.HotelDevice
{
    [TableColumn(Title = "Tên phòng ", FieldName = "HotelID", DataType = typeof(HotelService), Width = 100)]
    [TableColumn(Title = "Thiết bị ", FieldName = "HotelDeviceID", DataType = typeof(DeviceCommonService), Width = 100)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormHotelDevice : ManageModule<HotelDeviceService, HotelDeviceModel, FormUpdateHotelDevice>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên phòng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? HotelID { get; set; }
        /// <summary>
        /// Tên thiết bị
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string HotelDeviceName { get; set; }
        #endregion

        public FormHotelDevice(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách thiết bị";
        }
    }
}
