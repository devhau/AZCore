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
    public class PurchaseOrderProductService : EntityService< PurchaseOrderProductModel>, IAZTransient
    {
        public PurchaseOrderProductService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Chi tiết sản phẩm đi kèm hóa đơn
    /// </summary>

    [TableInfo(TableName = "az_sale_purchase_order_product")]
    public class PurchaseOrderProductModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Mã đơn nhập/ xuất
        /// </summary>
        [Field]
        public long PurchaseOrderId { get; set; }
        /// <summary>
        /// Mã Sản phẩm (SKU)
        /// </summary>
        [Field]
        public long ProductId { get; set; }
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
        /// Số lượng kho sau khi nhập/xuất
        /// </summary>
        [Field]
        public long Available { get; set; }
    }
}
