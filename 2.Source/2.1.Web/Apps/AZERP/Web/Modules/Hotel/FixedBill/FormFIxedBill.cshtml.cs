using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.FixedBill
{
    [TableColumn(Title = "Mã hóa đơn", FieldName = "Code", Width = 150)]
    [TableColumn(Title = "Tên hóa đơn", FieldName = "Name", Width = 150)]
    [TableColumn(Title = "Hợp đồng", FieldName = "ContractID", Width = 150, DataType = typeof(ContractService))]
    [TableColumn(Title = "Chủ nhà", FieldName = "BossID", Width = 150)]
    [TableColumn(Title = "Người thuê trọ", FieldName = "RenterID", Width = 150, DataType = typeof(RenterService))]
    [TableColumn(Title = "Tiền phòng", FieldName = "RoomCharge", FormatString = "{0:#,###}", Width = 150)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormFixedBill : ManageModule<FixedBillService, FixedBillModel, FormUpdateFixedBill>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên hóa đơn
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public String Name { get; set; }
        /// <summary>
        /// Hợp đồng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? ContractID { get; set; }
        /// <summary>
        /// Chủ nhà
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? BossID { get; set; }
        /// <summary>
        /// Người thuê trọ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long? RenterID { get; set; }
        /// <summary>
        /// Tiền phòng
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public decimal? RoomCharge { get; set; }
        #endregion

        public FormFixedBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách hóa đơn cố định";
        }
    }
}
