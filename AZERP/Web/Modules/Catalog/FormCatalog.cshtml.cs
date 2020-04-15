using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Catalog
{
    [TableColumn(Title = "Mã nhóm", FieldName = "Code")]
    [TableColumn(Title = "Nhóm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", DataType =typeof(CatalogService))]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 , DataType =typeof(EntityStatus))]
    public class FormCatalog : ManageModule<CatalogService, CatalogModel, FormUpdateCatalog>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên Danh Mục
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormCatalog(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý danh mục";
        }
    }
}
