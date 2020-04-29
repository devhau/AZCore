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
    [TableColumn(Title = "Mã kho", FieldName = "Code")]
    [TableColumn(Title = "Tên kho", FieldName = "Name")]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber")]
    [TableColumn(Title = "Tổng số lượng sản phẩm", FieldName = "Available")]
    [TableColumn(Title = "Ngày khởi tạo", FieldName = "CreateAt")]
    [TableColumn(Title = "Cập nhật cuối", FieldName = "UpdateAt")]
    [TableColumn(Title = "Trạng Thái", FieldName = "Status", DataType = typeof(EntityStatus))]
    public class FormStore : ManageModule<StoreService, StoreModel, FormUpdateStore>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã kho
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Code { get; set; }
        /// <summary>
        /// Tên kho
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormStore(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý kho";
        }
    }
}
