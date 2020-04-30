using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AZERP.Web.Modules.Customers
{
    [TableColumn(Title = "Mã đơn hàng", FieldName = "Code")]
    [TableColumn(Title = "Trạng thái", FieldName = "PurchaseOrderStatus", DataType = typeof(OrderStatus))]
    [TableColumn(Title = "Thanh toán", FieldName = "PurchaseOrderPayment", DataType = typeof(OrderPayment))]
    [TableColumn(Title = "Xuất kho", FieldName = "PurchaseOrderImport", DataType = typeof(PurchaseOrderImport))]
    [TableColumn(Title = "Tổng tiền", FieldName = "TotalNumber", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt")]
    [TableColumn(Title = "Cập nhật cuối", FieldName = "UpdateAt")]
    public class FormCusHistory : ManageModule<PurchaseOrderService, PurchaseOrderModel>
    {
        #region -- Field Search --
        /// <summary>
        /// Lọc hóa đơn xuất
        /// </summary>
        [QuerySearch]
        public OrderType Type { get; set; } = OrderType.Out;
        /// <summary>
        /// Lọc hóa đơn theo khách hàng
        /// </summary>
        [QuerySearch]
        public long PartnerId { get; set; }
        #endregion

        [BindQuery]
        public long Id { get; set; }
        [BindService]
        public CustomersService CustomersService;

        public FormCusHistory(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
        }

        public override IView Get()
        {
            var obj = this.CustomersService.GetById(this.Id);
            this.Title = obj.Code + " - " + obj.FullName;
            this.PartnerId = Id;
            return base.Get();
        }

        public override List<PurchaseOrderModel> GetSearchData()
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
                T.AddWhere("Type", OrderType.Out);

            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                actionWhere(T);
            });
            this.PageMax = (int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize);
            return Service.ExecuteQuery((T) => {
                if (PageIndex <= 0)
                {
                    PageIndex = 1;
                }
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
                T.Join("az_purchase_order_product", (t1, t2) => string.Format("{0}.Id={1}.PurchaseOrderId", t1, t2));
                T.SetColumn("az_purchase_order.*,sum(az_purchase_order_product.ImportPrice * az_purchase_order_product.ImportNumber) TotalNumber");
                T.AddGroup("az_purchase_order.id");
            }).ToList();
        }
    }
}
