using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Bill
{
    [TableColumn(Title = "Mã SP", FieldName = "Code")]
    [TableColumn(Title = "Tên SP", FieldName = "Name")]
    [TableColumn(Title = "Giá Bán (VNĐ)", FieldName = "Price", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Danh Mục", FieldName = "CatalogId", DataType = typeof(CatalogService))]
    [TableColumn(Title = "Mô Tả", FieldName = "Description")]
    [TableColumn(Title = "Trạng Thái", FieldName = "Status", DataType = typeof(EntityStatus))]
    public class FormProduct : ManageModule<ProductService, ProductModel, FormUpdateProduct>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên Sản Phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Nhóm SP
        /// </summary>
        [QuerySearch]
        public long? CatalogId { get; set; }
        #endregion

        public FormProduct(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý sản phẩm";
        }
    }
}
