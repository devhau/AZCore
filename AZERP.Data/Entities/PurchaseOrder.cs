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
        /// Mã nhà cung cấp
        /// </summary>
        [Field]
        public long SupplierCode { get; set; }
        /// <summary>
        /// Mã Sản phẩm (SKU)
        /// </summary>
        [Field]
        public long ProductCode { get; set; }
        /// <summary>
        /// Giá nhập sản phẩm
        /// </summary>
        [Field]
        public long ImportPrice { get; set; }
        /// <summary>
        /// Số lượng nhập
        /// </summary>
        [Field]
        public long ImportNumber{ get; set; }
        /// <summary>
        /// Nhân viên tạo đơn
        /// </summary>
        [Field]
        public long AccountId { get; set; }
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
        /// Mã kho hàng
        /// </summary>
        [Field]
        public long StoreCode { get; set; }
        /// <summary>
        /// Chi phí
        /// </summary>
        [Field]
        public long LandedCost { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
        /// <summary>
        /// Trạng thái hóa đơn
        /// </summary>
        [Field]
        public PurchaseOrderStatus PurchaseOrderStatus { get; set; }
        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        [Field]
        public PurchaseOrderPayment PurchaseOrderPayment { get; set; }
        /// <summary>
        /// Trạng thái nhập kho
        /// </summary>
        [Field]
        public PurchaseOrderImport PurchaseOrderImport { get; set; }
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
        /// Ngày duyệt
        /// </summary>
        [Field]
        public DateTime ClosedOn { get; set; }
    }
}
