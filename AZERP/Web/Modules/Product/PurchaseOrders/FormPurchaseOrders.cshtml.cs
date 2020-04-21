using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
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
