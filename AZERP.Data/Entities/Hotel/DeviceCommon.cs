using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class DeviceCommonService : EntityService<DeviceCommonService, DeviceCommonModel>, IAZTransient
    {
        public DeviceCommonService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin thiết bị
    /// </summary>

    [TableInfo(TableName = "az_hotel_device_common")]
    public class DeviceCommonModel : EntityModel<DeviceModel, long>
    {
        /// <summary>
        /// Mã thiết bị
        /// </summary>
        [Field]
        public string DeviceCommonCode { get; set; }
        /// <summary>
        /// Tên thiết bị
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string DeviceName { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
