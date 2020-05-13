using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class ContractService : EntityService<ContractService, ContractModel>, IAZTransient
    {
        public ContractService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin hợp đồng nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel_contract")]
    public class ContractModel : EntityModel<ContractModel, long>
    {
        /// <summary>
        /// Mã hợp đồng
        /// </summary>
        [FieldAutoGenCode(Key =SystemCode.ContractCode)]
        [Field]
        public long ContractID { get; set; }
        /// <summary>
        /// Tên hợp đồng
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string ContractName { get; set; }
        /// <summary>
        /// Mã chủ nhà
        /// </summary>
        [Field]
        [FieldDisplay]
        public long BossID { get; set; }
        /// <summary>
        /// Mã người thuê nhà
        /// </summary>
        [Field]
        [FieldDisplay]
        public long RenterID { get; set; }
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [Field]
        [FieldDisplay]
        public long HotelID { get; set; }
        /// <summary>
        /// Tiền đặt cọc
        /// </summary>
        [Field]
        [FieldDisplay]
        public decimal Deposit { get; set; }
        /// <summary>
        /// Số bạn cùng phòng
        /// </summary>
        [Field]
        [FieldDisplay]
        public int Quantity { get; set; }
        /// <summary>
        /// Loại hợp đồng
        /// Theo tháng
        /// Theo quý
        /// Theo nửa năm
        /// Theo năm
        /// </summary>
        [Field]
        [FieldDisplay]
        public long TypeOfContract { get; set; }
        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        [Field]
        [FieldDisplay]
        public DateTime TimeStart { get; set; }
        /// <summary>
        /// Thời gian kết thúc
        /// </summary>
        [Field]
        [FieldDisplay]
        public DateTime TimeEnd { get; set; }
        /// <summary>
        /// Trạng thái hợp đồng
        /// Chưa hoạt động
        /// Đang hoạt động
        /// Kết thúc
        /// </summary>
        [Field]
        [FieldDisplay]
        public string ContractStatus { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
