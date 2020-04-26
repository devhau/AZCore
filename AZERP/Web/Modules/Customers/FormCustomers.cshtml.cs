using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
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
    [TableColumn(Title = "Lịch sử", LinkFormat = "/khach-hang/lich-su-mua-hang.az", Text = "Lịch sử mua hàng", Display = AZWeb.Module.Enums.DisplayColumn.IconText, Icon = "fa fa-history", Popup = AZWeb.Module.Enums.PopupSize.Extralarge)]
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

        public FormCustomers(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Khách hàng";
        }
    }
}
