using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System.Data;

namespace AZERP.Data.Entities
{
    public class WidgetService : EntityService<WidgetService, WidgetModel>, IAZTransient
    {
        public WidgetService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của widget
    /// </summary>
    [TableInfo(TableName = "az_widget")]
    public class WidgetModel : EntityModel<WidgetModel, long>
    {
        /// <summary>
        /// Cấu hình cho đơn vị nào
        /// </summary>
        [Field]
        public long? TenantId { get; set; }
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
