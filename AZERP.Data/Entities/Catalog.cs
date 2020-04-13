using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CatalogService : EntityService<CatalogService, CatalogModel>, IAZTransient
    {
        public CatalogService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>

    [TableInfo(TableName = "az_catalog")]
    public class CatalogModel : EntityModel<CatalogModel, long>
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
        /// Mã code BAC
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
    }
}
