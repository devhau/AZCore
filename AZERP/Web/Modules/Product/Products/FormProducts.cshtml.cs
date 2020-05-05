using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Product.Products
{
    [TableColumn(Title = "", FieldName = "Picture")]
    [TableColumn(Title = "Mã SKU", FieldName = "Code")]
    [TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm sản phẩm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    [TableColumn(Title = "Giá bán lẻ (VNĐ)", FieldName = "RetailPrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Giá bán buôn (VNĐ)", FieldName = "WholesalePrice", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Có thể bán", FieldName = "Available")]
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

        public override List<ProductModel> GetSearchData()
        {
            var proper = this.GetType().GetPropertyByQuerySearch();
            Action<QuerySQL> actionWhere = (T) =>
            {
                foreach (var p in proper)
                {
                    if (p.Property.GetValue(this) != null)
                        T.AddWhere(p.Property.Name, p.Property.GetValue(this), p.OperatorSQL);
                }
            };
            this.PageTotalAll = Service.ExecuteNoneQuery((T) => {

                T.SetColumn("count(0)");

            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                actionWhere(T);
            });
            this.PageMax = this.PageSize>0?(int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize):0;
            return Service.ExecuteQuery((T) => {
                if (PageIndex <= 0)
                {
                    PageIndex = 1;
                }
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
                T.Join("az_store_product", (t1, t2) => string.Format("{0}.Id={1}.ProductId", t1, t2), JoinType.LeftOuterJoin);
                T.SetColumn("az_product.*, SUM(CASE WHEN az_store_product.Available IS NULL THEN 0 ELSE az_store_product.Available END) Available");
                T.AddGroup("az_product.id");
            }).ToList();
        }
    }
}
