using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class TotalBillService : EntityService<TotalBillService, TotalBillModel>, IAZTransient
    {
        public TotalBillService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn tổng
    /// </summary>

    [TableInfo(TableName = "az_hotel_totalbill")]
    public class TotalBillModel : EntityModel<TotalBillModel, long>
    {
        /// <summary>
        /// Mã hóa đơn tổng
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.TotalBillCode)]
        [Field]
        public long TotalBillID { get; set; }
        /// <summary>
        /// Tên hóa đơn
        /// ví dụ: tháng 3-2020
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string TotalBillName { get; set; }
        /// <summary>
        /// Mã đơn cố định
        /// </summary>
        [Field]
        public long FixedBillID { get; set; }
        /// <summary>
        /// Mã đơn lưu động
        /// </summary>
        [Field]
        public long ChangeBillID { get; set; }
        /// <summary>
        /// Tổng tiền
        /// </summary>
        [Field]
        public decimal TotalPricess { get; set; }
        /// <summary>
        /// Tiền nợ
        /// </summary>
        [Field]
        public decimal Debt { get; set; }
        /// <summary>
        /// Thời hạn nộp tiền
        /// </summary>
        [Field]
        public DateTime Deadline { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [Field]
        public string StatusBill { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
