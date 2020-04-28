using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Product.Products
{
    [TableColumn(Title = "Mã SKU", FieldName = "Code")]
    [TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm sản phẩm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    [TableColumn(Title = "Giá bán lẻ (VNĐ)", FieldName = "RetailPrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Giá bán buôn (VNĐ)", FieldName = "WholesalePrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Tồn kho", FieldName = "Available")]
    [TableColumn(Title = "Ngày khởi tạo", FieldName = "CreateAt", DataType = typeof(DateTime))]
    [TableColumn(Title = "Cập nhật cuối", FieldName = "UpdateAt", DataType = typeof(DateTime))]
    [TableColumn(Title = "Trạng Thái", FieldName = "ProductSellable", TextFalse = "Đang không hoạt động", TextTrue = "Đang hoạt động")]
    [ModuleInfo(
        Title = "Quản lý sản phẩm",
        ViewCode = Permissions.Permission.Product,
        AddCode = Permissions.Permission.Product_Add,
        EditCode = Permissions.Permission.Product_Edit,
        RemoveCode = Permissions.Permission.Product_Remove,
        ExportCode = Permissions.Permission.Product_Export,
        ImportCode = Permissions.Permission.Product_Import
        )]
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
        #endregion

        public FormProducts(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
