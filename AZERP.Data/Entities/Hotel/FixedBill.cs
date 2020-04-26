using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class FixedBillService : EntityService<FixedBillService, FixedBillModel>, IAZTransient
    {
        public FixedBillService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn cố định
    /// </summary>

    [TableInfo(TableName = "az_hotel_fixedbill")]
    public class FixedBillModel : EntityModel<FixedBillModel, long>
    {
        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        [Field(Length = 500)]
        public string FixedBillID { get; set; }
        /// <summary>
        /// Tên hóa đơn
        /// ví dụ: tháng 3-2020
        /// </summary>
        [Field(Length = 500)]
        public string FixedBillName { get; set; }
        /// <summary>
        /// Mã người thuê trọ
        /// </summary>
        [Field]
        public long RenterID { get; set; }
        /// <summary>
        /// Mã chi phí
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
