using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class ProductService : EntityService<ProductService, ProductModel>, IAZTransient
    {
        public ProductService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của sản phẩm
    /// </summary>

    [TableInfo(TableName = "az_product")]
    public class ProductModel : EntityModel<ProductModel, long>
    {
        /// <summary>
        /// Mã SP/ SKU
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.ProdcutCode)]
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Phân loại sản phẩm
        /// </summary>
        [Field]
        public long CategoryId { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
        /// <summary>
        /// Giá bán lẻ sản phẩm
        /// </summary>
        [Field]
        public long RetailPrice { get; set; }
        /// <summary>
        /// Giá bán buôn sản phẩm
        /// </summary>
        [Field]
        public long WholesalePrice { get; set; }
        /// <summary>
        /// Giá nhập
        /// </summary>
        [Field]
        public Decimal ImportPrice { get; set; }
        /// <summary>
        /// Sản phảm có/không được phép bán
        /// </summary>
        [Field]
        public bool ProductSellable { get; set; }
        /// <summary>
        /// Sản phẩm có/không áp dụng thuế
        /// </summary>
        [Field]
        public bool ProductTaxable { get; set; }
        /// <summary>
        /// Khối lượng sản phẩm
        /// </summary>
        [Field]
        public long WeightValue { get; set; }
        /// <summary>
        /// Số lượng hàng đang về
        /// </summary>
        public long Incoming { get; set; }
        /// <summary>
        /// Số lượng hàng đang giao
        /// </summary>
        public long OnWay { get; set; }
        /// <summary>
        /// Số lượng hàng đang giao dịch
        /// </summary>
        public long Committed { get; set; }
        /// <summary>
        /// Tổng số lượng có thể bán (từ nhiều kho)
        /// </summary>
        public long Available { get; set; }
    }
}
