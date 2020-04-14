using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
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
        /// Mã SP
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        [Field]
        public long CatalogId { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        [Field(Length = 500)]
        public string Name { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
        /// <summary>
        /// Giá SP
        /// </summary>
        [Field]
        public long Price { get; set; }
    }
}
