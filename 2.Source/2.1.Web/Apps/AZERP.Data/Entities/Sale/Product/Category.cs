﻿using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CategoryService : EntityService< CategoryModel>, IAZTransient
    {
        public CategoryService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>

    [TableInfo(TableName = "az_sale_Category")]
    public class CategoryModel : EntityTenantModel< long>
    {
        /// <summary>
        /// Nhóm cha
        /// </summary>
        [Field]
        public long ParentId { get; set; }
        /// <summary>
        /// Tên nhóm
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Mã code
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        [Field(Length = 500)]
        public string Note { get; set; }
    }
}
