using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Product.Variants
{
    //[TableColumn(Title = "Mã SKU", FieldName = "Code")]
    //[TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    //[TableColumn(Title = "Nhóm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    //[TableColumn(Title = "Tồn kho", FieldName = "Available")]
    //[TableColumn(Title = "Hàng đang về", FieldName = "Incoming")]
    //[TableColumn(Title = "Hàng đang giao", FieldName = "OnWay")]
    //[TableColumn(Title = "Đang giao dịch", FieldName = "Committed")]
    //[TableColumn(Title = "Trạng Thái", FieldName = "ProductSellable", TextFalse = "Đang không hoạt động", TextTrue = "Đang hoạt động")]
    public class FormVariants : ManageModule<ProductService, ProductModel, FormUpdateVariants>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Code { get; set; }
        /// <summary>
        /// Tên Sản Phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Mã kho
        /// </summary>
        [BindQuery]
        public long StoreId { get; set; } = 0;
        #endregion

        [BindService]
        public StoreService StoreService;

        public List<StoreModel> storeModels;
        public List<VariantData> variantDatas;

        public long GetInfo(long storeId, long productId, Func<VariantData, long> func)
        {
            var item = variantDatas.FirstOrDefault(p => p.StoreId == storeId && p.ProductId == productId);
            return item == null ? 0 : func(item);
        }

        public override List<ProductModel> GetSearchData()
        {
            if (this.StoreId == 0)
            {
                this.storeModels = StoreService.GetAll().ToList();
            }
            else
            {
                this.storeModels = StoreService.Select(p => p.Id == this.StoreId).ToList();
            }

            this.variantDatas = StoreService.GetObject(this.StoreId).ToList();

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
            this.PageMax = (int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize);
            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
            return Service.ExecuteQuery((T) => {
                T.Pagination(PageIndex, PageSize);
                //T.Join("az_purchase_order_product", (t1, t2) =>$"{t1}.Id={t2}.ProductId", JoinType.LeftOuterJoin);
                //T.Join("az_purchase_order_product", "az_purchase_order", (t1, t2) => $"{ t1}.PurchaseOrderId={t2}.Id", JoinType.LeftOuterJoin);
                //T.SetColumn(@" az_product.* , 
                //  SUM(CASE  WHEN az_purchase_order.Type = 0 AND az_purchase_order.PurchaseOrderImport = 0 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Incoming,
                //  SUM(CASE  WHEN az_purchase_order.Type = 1 AND az_purchase_order.PurchaseOrderImport = 3 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) OnWay,
                //  SUM(CASE  WHEN az_purchase_order.Type = 1 AND az_purchase_order.PurchaseOrderImport = 2 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Committed
                //    ");
                //T.AddGroup("az_product.Id");
                actionWhere(T);
            }).ToList();
        }
        public FormVariants(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý tồn kho";
        }
    }
}
