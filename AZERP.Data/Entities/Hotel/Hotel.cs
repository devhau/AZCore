using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities.Hotel
{
    public class HotelService : EntityService<HotelService, HotelModel>, IAZTransient
    {
        public HotelService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel")]
    public class HotelModel : EntityModel<HotelModel, long>
    {
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [Field(Length = 500)]
        public string HotelID { get; set; }
        /// <summary>
        /// Tên phòng trọ
        /// </summary>
        [Field(Length = 500)]
        public string HotelName { get; set; }
        /// <summary>
        /// Mã loại phòng trọ
        /// </summary>
        [Field(Length = 500)]
        public string TypeOfHotelID { get; set; }
        /// <summary>
        /// Mã khu vực
        /// </summary>
        [Field(Length = 500)]
        public string AreaID { get; set; }
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
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
