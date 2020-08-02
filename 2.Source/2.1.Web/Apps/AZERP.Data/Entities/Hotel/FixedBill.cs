using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System.Data;

namespace AZERP.Data.Entities
{
    public class FixedBillService : EntityService< FixedBillModel>, IAZTransient
    {
        public FixedBillService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của hóa đơn cố định
    /// </summary>

    [TableInfo(TableName = "az_hotel_fixed_bill")]
    public class FixedBillModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Mã hóa đơn cố định
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.FixedBillCode)]
        [Field]
        public long FixedBillCode { get; set; }
        /// <summary>
        /// Tên hóa đơn cố định
        /// </summary>
        [Field]
        [FieldDisplay]
        public string FixedBillName { get; set; }
        /// <summary>
        /// Mã hợp đồng
        /// </summary>
        [Field]
        public long ContractID { get; set; }
        /// <summary>
        /// Mã chủ nhà
        /// </summary>
        [Field]
        public long BossID { get; set; }
        /// <summary>
        /// Mã người thuê trọ
        /// </summary>
        [Field]
        public long RenterID { get; set; }
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
