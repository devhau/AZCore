using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class PurchaseOrderService : EntityService<PurchaseOrderService, PurchaseOrderModel>, IAZTransient
    {
        public PurchaseOrderService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin hóa đơn nhập
    /// </summary>

    [TableInfo(TableName = "az_purchase_order")]
    public class PurchaseOrderModel : EntityModel<PurchaseOrderModel, long>
    {
        /// <summary>
        /// Mã đơn nhập
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Id nhà cung cấp / khách hàng
        /// </summary>
        [Field]
        public long PartnerId { get; set; }
        /// <summary>
        /// Nhân viên duyệt đơn
        /// </summary>
        [Field]
        public long ActivedAccountId{ get; set; }
        /// <summary>
        /// Nhân viên hủy đơn
        /// </summary>
        [Field]
        public long CancelledAccountId { get; set; }
        /// <summary>
        /// Nhân viên kết thúc đơn
        /// </summary>
        [Field]
        public long ClosedAccountId { get; set; }
        /// <summary>
        /// Mã chi phí
        /// </summary>
        [Field]
        public long CostId { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [Field]
        public OrderStatus PurchaseOrderStatus { get; set; }
        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        [Field]
        public OrderPayment PurchaseOrderPayment { get; set; }
        /// <summary>
        /// Trạng thái nhập / xuất kho
        /// </summary>
        [Field]
        public PurchaseOrderImport PurchaseOrderImport { get; set; }
        /// <summary>
        /// Kiểu hóa đơn nhập/xuất
        /// </summary>
        [Field]
        public OrderType Type { get; set; }
        /// <summary>
        /// Ngày duyệt
        /// </summary>
        [Field]
        public DateTime ActivatedOn { get; set; }
        /// <summary>
        /// Ngày hoàn thành
        /// </summary>
        [Field]
        public DateTime CompleteOn { get; set; }
        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        [Field]
        public DateTime ClosedOn { get; set; }
        /// <summary>
        /// Tổng số tiền trên 1 hóa đơn
        /// </summary>
        public long TotalNumber { get; set; }
    }
}
