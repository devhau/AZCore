using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Product.Products
{
    [TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm sản phẩm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    [TableColumn(Title = "Giá bán lẻ (VNĐ)", FieldName = "RetailPrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Giá bán buôn (VNĐ)", FieldName = "WholesalePrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Tồn kho", FieldName = "Available")]
    [TableColumn(Title = "Ngày khởi tạo", FieldName = "CreateAt", DataType = typeof(DateTime))]
    [TableColumn(Title = "Cập nhật cuối", FieldName = "UpdateAt", DataType = typeof(DateTime))]
    public class FormProducts : ManageModule<ProductService, ProductModel, FormUpdateProducts>
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
        public long? CategoryId { get; set; }
        [QuerySearch]
        public bool ProductSellable { get; set; } = true;
        #endregion

        public FormProducts(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý sản phẩm";
        }
    }
}
