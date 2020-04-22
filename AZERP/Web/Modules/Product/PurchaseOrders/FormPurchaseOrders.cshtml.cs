using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Product.PurchaseOrders
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    [TableColumn(Title = "Nhà cung cấp", FieldName = "SupplierCode", DataType = typeof (SupplierService))]
    [TableColumn(Title = "Trạng thái", FieldName = "PurchaseOrderStatus", DataType = typeof(OrderStatus))]
    [TableColumn(Title = "Thanh toán", FieldName = "PurchaseOrderPayment", DataType = typeof(OrderPayment))]
    [TableColumn(Title = "Nhập kho", FieldName = "PurchaseOrderImport", DataType = typeof(PurchaseOrderImport))]
    [TableColumn(Title = "Tổng tiền")]
    [TableColumn(Title = "Nhân viên tạo", FieldName = "CreateBy")]
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt")]
    public class FormPurchaseOrders : ManageModule<PurchaseOrderService, PurchaseOrderModel, FormUpdatePurchaseOrders>
    {
        public FormPurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý đơn nhập hàng";
        }
        [BindForm]
        public List<PurchaseOrderProductModel> listDataOrder { get; set; }
    }
}
