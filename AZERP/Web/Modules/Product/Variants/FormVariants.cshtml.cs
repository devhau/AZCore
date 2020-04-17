using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Product.Variants
{
    [TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    [TableColumn(Title = "Mã SKU", FieldName = "Code")]
    [TableColumn(Title = "Nhóm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    [TableColumn(Title = "Tồn kho", FieldName = "Available")]
    [TableColumn(Title = "Hàng đang về", FieldName = "Incoming")]
    [TableColumn(Title = "Hàng đang giao", FieldName = "OnWay")]
    [TableColumn(Title = "Đang giao dịch", FieldName = "Committed")]
    [TableColumn(Title = "Trạng Thái", FieldName = "ProductSellable", TextFalse = "Đang không hoạt động", TextTrue = "Đang hoạt động")]
    public class FormVariants : ManageModule<ProductService, ProductModel, FormUpdateVariants>
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

        public FormVariants(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý kho";
        }
    }
}
