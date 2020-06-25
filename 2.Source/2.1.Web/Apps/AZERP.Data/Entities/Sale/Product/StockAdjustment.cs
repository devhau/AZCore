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
    public class StockAdjusmentService : EntityService<StockAdjusmentService, StockAdjusmentModel>, IAZTransient
    {
        public StockAdjusmentService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin hóa đơn kiểm hàng
    /// </summary>

    [TableInfo(TableName = "az_sale_stock_adjustment")]
    public class StockAdjusmentModel : EntityModel<StockAdjusmentModel, long>
    {
        /// <summary>
        /// Mã đơn kiểm
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Mã kho hàng
        /// </summary>
        [Field]
        public long StoreCode { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>
        [Field]
        public StockAdjustmentStatus StockAdjusmentStatus { get; set; }
        /// <summary>
        /// Ngày kiểm hàng
        /// </summary>
        [Field]
        public DateTime? AdjustedOn { get; set; }
        /// <summary>
        /// Nhân viên tạo đơn
        /// </summary>
        [Field]
        public long AccountId { get; set; }
        /// <summary>
        /// Mã Sản phẩm (SKU)
        /// </summary>
        [Field]
        public long ProductCode { get; set; }
        /// <summary>
        /// Số lượng nhập
        /// </summary>
        [Field]
        public long TotalQuantity { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field]
        public string Note { get; set; }
    }
}
