using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;

namespace AZERP.Web.Modules.Product.Supplier
{
    [TableColumn(Title = "Mã nhà cung cấp", FieldName = "Code")]
    [TableColumn(Title = "Tên nhà cung cấp", FieldName = "Name")]
    [TableColumn(Title = "Số điện thoại", FieldName = "AbbreviatedName")]
    [TableColumn(Title = "Email", FieldName = "AbbreviatedName")]
    [TableColumn(Title = "Trạng thái", FieldName = "SupplierStatus", TextFalse = "Ngưng hoạt động", TextTrue = "Đang hoạt động")]
    public class FormSupplier : ManageModule<SupplierService, SupplierModel, FormUpdateSupplier>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên nhà cung cấp
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormSupplier(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Nhà cung cấp";
        }
    }
}
