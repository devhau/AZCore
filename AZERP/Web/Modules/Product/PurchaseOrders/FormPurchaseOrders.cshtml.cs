using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.PurchaseOrders.PurchaseOrders
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    [TableColumn(Title = "Nhà cung cấp", FieldName = "Code")]
    [TableColumn(Title = "Nhóm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    [TableColumn(Title = "Tồn kho", FieldName = "Available")]
    [TableColumn(Title = "Hàng đang về", FieldName = "Incoming")]
    [TableColumn(Title = "Hàng đang giao", FieldName = "OnWay")]
    [TableColumn(Title = "Đang giao dịch", FieldName = "Committed")]
    [TableColumn(Title = "Trạng Thái", FieldName = "Status", DataType = typeof(EntityStatus))]
    public class FormPurchaseOrders : ManageModule<PurchaseOrdersService, PurchaseOrdersModel, FormUpdatePurchaseOrders>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên Sản Phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormPurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý đơn nhập hàng";
        }
    }
}
