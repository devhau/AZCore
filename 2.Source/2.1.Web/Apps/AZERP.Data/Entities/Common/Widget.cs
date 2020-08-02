using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class WidgetService : EntityService< WidgetModel>, IAZTransient
    {
        public WidgetService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    /// <summary>
    /// Thông tin của widget
    /// </summary>
    [TableInfo(TableName = "az_common_widget")]
    public class WidgetModel : EntityTenantModel<long>
    {
        /// <summary>
        /// Cấu hình theo từng người
        /// </summary>
        [Field]
        public long? UserId { get; set; }
        /// <summary>
        /// Tên Widget
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Widget
        /// </summary>
        [Field(Length = 500)]
        public string Widget { get; set; }
        /// <summary>
        /// Thiết lập
        /// </summary>
        [Field(Length = 10000)]
        public string Setting { get; set; }
    }
}
