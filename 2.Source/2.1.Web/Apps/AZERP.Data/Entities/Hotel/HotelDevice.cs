using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class HotelDeviceService : EntityService<HotelDeviceService, HotelDeviceModel>, IAZTransient
    {
        public HotelDeviceService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của khu vực
    /// </summary>

    [TableInfo(TableName = "az_hotel_device")]
    public class HotelDeviceModel : EntityTenantModel<HotelDeviceModel, long>
    {
        /// <summary>
        /// Tên phòng trọ
        /// </summary>
        [Field]
        public long HotelID { get; set; }
        /// <summary>
        /// Tên thiết bị
        /// </summary>
        [Field]
        public long DeviceID { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
