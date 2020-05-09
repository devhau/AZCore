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
        /// Tên Widget
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Mã code
        /// </summary>
        [Field(Length = 500)]
        public string Code { get; set; }
    }
}
