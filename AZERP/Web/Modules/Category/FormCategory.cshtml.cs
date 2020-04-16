using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Category
{
    [TableColumn(Title = "Mã nhóm", FieldName = "Code")]
    [TableColumn(Title = "Nhóm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", DataType =typeof(CategoryService))]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 , DataType =typeof(EntityStatus))]
    public class FormCategory : ManageModule<CategoryService, CategoryModel, FormUpdateCategory>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên Danh Mục
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormCategory(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý danh mục";
        }
    }
}
