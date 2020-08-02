using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class HotelService : EntityService< HotelModel>, IAZTransient
    {
        public HotelService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel")]
    public class HotelModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.HotelCode)]
        [Field]
        public string HotelCode { get; set; }
        /// <summary>
        /// Tên phòng trọ
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string HotelName { get; set; }
        /// <summary>
        /// Mã loại phòng trọ
        /// </summary>
        [Field]
        public long TypeOfHotelID { get; set; }
        /// <summary>
        /// Mã khu vực
        /// </summary>xóa
        [Field]
        public long AreaID { get; set; }
        /// <summary>
        /// Trạng thái sử dụng của nhà trọ
        /// 1. Chưa hoạt động
        /// 2. Đang hoạt động : chưa có người sử dụng
        /// 3. Đang hoạt động : có người sử dụng
        /// 4. Khác
        /// </summary>
        [Field]
        public HotelStatus? HotelStatus { get; set; }
        /// <summary>
        /// Tiền phòng
        /// </summary>
        [Field]
        public decimal RoomCharge { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
