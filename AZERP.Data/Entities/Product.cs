﻿using AZCore.Database;
using AZCore.Database.Attr;
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
    }
}