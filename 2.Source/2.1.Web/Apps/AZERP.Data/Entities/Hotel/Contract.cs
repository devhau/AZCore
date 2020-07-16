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
        public ContractService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin hợp đồng nhà trọ
    /// </summary>

    [TableInfo(TableName = "az_hotel_contract")]
    public class ContractModel : EntityTenantModel<ContractModel, long>
    {
        /// <summary>
        /// Mã hợp đồng
        /// </summary>
        [FieldAutoGenCode(Key =SystemCode.ContractCode)]
        [Field]
        public string ContractCode { get; set; }
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
        public long BossID { get; set; }
        /// <summary>
        /// Mã người thuê nhà
        /// </summary>
        [Field]
        public long RenterID { get; set; }
        /// <summary>
        /// Mã phòng trọ
        /// </summary>
        [Field]
        public long HotelID { get; set; }
        /// <summary>
        /// Tiền đặt cọc
        /// </summary>
        [Field]
        public decimal Deposit { get; set; }
        /// <summary>
        /// Số bạn cùng phòng
        /// </summary>
        [Field]
        public int Quantity { get; set; }
        /// <summary>
        /// Loại hợp đồng
        /// Theo tháng
        /// Theo quý
        /// Theo nửa năm
        /// Theo năm
        /// </summary>
        [Field]
        public TypeOfContract? TypeOfContract { get; set; }
        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        [Field]
        public DateTime TimeStart { get; set; }
        /// <summary>
        /// Thời gian kết thúc
        /// </summary>
        [Field]
        public DateTime TimeEnd { get; set; }
        /// <summary>
        /// Trạng thái hợp đồng
        /// Chưa hoạt động
        /// Đang hoạt động
        /// Kết thúc
        /// </summary>
        [Field]
        public TypeOfContractStatus? ContractStatus { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
