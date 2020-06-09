using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Payment
{
    [TableColumn(Title = "Mã thanh toán ", FieldName = "Code", Width = 150)]
    [TableColumn(Title = "Hóa đơn tổng", FieldName = "TotalBillID", DataType =typeof(TotalBillService), Width = 150)]
    [TableColumn(Title = "Tiền nộp", FieldName = "Price", FormatString = "{0:#,###}", Width = 150)]
    [TableColumn(Title = "Thời gian nộp", FieldName = "PaymentDate", Width = 150)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormPayment : ManageModule<PaymentService, PaymentModel, FormUpdatePayment>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã thanh toán
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Code { get; set; }
        /// <summary>
        /// Hóa đơn tổng
        /// </summary>
        [QuerySearch]
        public string TotalBillID { get; set; }
        /// <summary>
        /// Tiền nộp
        /// </summary>
        [QuerySearch]
        public decimal? Price { get; set; }
        /// <summary>
        /// Thời gian nộp
        /// </summary>
        [QuerySearch]
        public DateTime? Deadline { get; set; }
        #endregion
        public FormPayment(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách thanh toán";
        }
    }
}
