using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.ChangeBill
{
    [TableColumn(Title = "Mã hóa đơn ", FieldName = "ChangeBillID", Width = 100)]
    [TableColumn(Title = "Tháng", FieldName = "Month")]
    [TableColumn(Title = "Năm", FieldName = "Year")]
    [TableColumn(Title = "Loại dịch vụ", FieldName = "TypeOfService")]
    [TableColumn(Title = "Giá tiền", FieldName = "Price")]
    [TableColumn(Title = "Số điện trước", FieldName = "NumberBefore")]
    [TableColumn(Title = "Số điện hiện tại", FieldName = "NumberCurrent")]
    [TableColumn(Title = "Số lượng", FieldName = "Quantity")]
    [TableColumn(Title = "Đơn vị", FieldName = "Unit")]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormChangeBill : ManageModule<ChangeBillService, ChangeBillModel, FormUpdateChangeBill>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string TypeOfService { get; set; }
        #endregion

        public FormChangeBill(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hóa Đơn Di Động";
        }
    }
}
