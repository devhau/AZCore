using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Product.Products
{
    [TableColumn(Title = "Nhóm sản phẩm", FieldName = "Name")]
    [TableColumn(Title = "Mã nhóm", FieldName = "Code")]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", DataType =typeof(CategoryService))]
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
