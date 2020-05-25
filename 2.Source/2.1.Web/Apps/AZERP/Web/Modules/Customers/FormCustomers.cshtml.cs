using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;

namespace AZERP.Web.Modules.Customers
{
    [TableColumn(Title = "Mã khách hàng", FieldName = "Code")]
    [TableColumn(Title = "Tên khách hàng", FieldName = "FullName")]
    [TableColumn(Title = "Giới tính", FieldName = "Gender")]
    [TableColumn(Title = "Email", FieldName = "Email")]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber")]
    [TableColumn(Title = "Trạng thái", FieldName = "CustomersStatus", TextFalse = "Ngưng hoạt động", TextTrue = "Đang hoạt động")]
    [TableColumn(Title = "Lịch sử", LinkFormat = "/khach-hang/lich-su-mua-hang.az?Id={Id}", Text = "Lịch sử mua hàng", Display = AZWeb.Module.Enums.DisplayColumn.IconText, Icon = "fa fa-history", Popup = AZWeb.Module.Enums.PopupSize.Extralarge)]
    [ModuleInfo(
        Title = "Khách hàng",
        ViewCode = Permissions.Permission.Cus,
        AddCode = Permissions.Permission.Cus_Add,
        EditCode = Permissions.Permission.Cus_Edit,
        RemoveCode = Permissions.Permission.Cus_Remove,
        ExportCode = Permissions.Permission.Cus_Export,
        ImportCode = Permissions.Permission.Cus_Import
        )]
    public class FormCustomers : ManageModule<CustomersService, CustomersModel, FormUpdateCustomers>
    {
        #region -- Field Search --
        /// <summary>
        /// Họ Tên
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        [QuerySearch]
        public Gender? Gender { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string PhoneNumber { get; set; }
        #endregion

        [BindQuery]
        public long Id { get; set; }

        public FormCustomers(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
