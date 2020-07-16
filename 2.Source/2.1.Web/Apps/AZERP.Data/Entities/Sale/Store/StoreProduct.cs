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
    public class StoreProductService : EntityService<StoreProductService, StoreProductModel>, IAZTransient
    {
        public StoreProductService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Chi tiết sản phẩm với kho
    /// </summary>

    [TableInfo(TableName = "az_sale_store_product")]
    public class StoreProductModel : EntityTenantModel<StoreProductModel, long>
    {
        /// <summary>
        /// Mã kho
        /// </summary>
        [Field]
        public long StoreId { get; set; }
        /// <summary>
        /// Mã Sản phẩm (SKU)
        /// </summary>
        [Field]
        public long ProductId { get; set; }
        /// <summary>
        /// Tồn kho
        /// </summary>
        [Field]
        public long Available { get; set; }
        /// <summary>
        /// Số lượng tối đa
        /// </summary>
        [Field]
        public long MaxAvailable { get; set; }
    }
}
