using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class ChangeBillService : EntityService<ChangeBillService, ChangeBillModel>, IAZTransient
    {
        public ChangeBillService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn cố định
    /// </summary>

    [TableInfo(TableName = "az_hotel_changebill")]
    public class ChangeBillModel : EntityModel<ChangeBillModel, long>
    {
        /// <summary>
        /// Mã hóa đơn
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.ChangeBillCode)]
        [Field(Length = 500)]
        public string ChangeBillID { get; set; }
        /// <summary>
        /// Tháng thuê trọ
        /// </summary>
        [Field(Length = 2)]
        public int Month { get; set; }
        /// <summary>
        /// Năm thuê trọ
        /// </summary>
        [Field(Length = 4)]
        public int Year { get; set; }
        /// <summary>
        /// Loại dịch vụ
        /// </summary>
        [Field]
        public long TypeOfService { get; set; }
        /// <summary>
        /// Đơn giá
        /// </summary>
        [Field]
        public decimal Price { get; set; }
        /// <summary>
        /// Số điện tháng trước
        /// </summary>
        [Field]
        public int NumberBefore { get; set; }
        /// <summary>
        /// Số điện hiện tại
        /// </summary>
        [Field]
        public int NumberCurrent { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        [Field]
        public int Quantity { get; set; }
        /// <summary>
        /// Đơn vị
        /// </summary>
        [Field(Length = 500)]
        public string Unit { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
