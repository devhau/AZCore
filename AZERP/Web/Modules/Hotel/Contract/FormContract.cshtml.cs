using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Contract
{
    [TableColumn(Title = "Mã hợp đồng ", FieldName = "ContractCode", Width = 150)]
    [TableColumn(Title = "Tên hợp đồng", FieldName = "ContractName", Width = 150)]
    [TableColumn(Title = "Chủ nhà", FieldName = "BossID",  Width = 150)]
    [TableColumn(Title = "Người thuê nhà", FieldName = "RenterID", DataType = typeof(RenterService), Width = 200)]
    [TableColumn(Title = "Phòng trọ", FieldName = "HotelID" , Width = 150)]
    [TableColumn(Title = "Tiền đặt cọc", FieldName = "Deposit", Width = 150)]
    [TableColumn(Title = "Số bạn cùng phòng", FieldName = "Quantity", Width = 200)]
    [TableColumn(Title = "Loại hợp đồng", FieldName = "TypeOfContract" , Width = 150)]
    [TableColumn(Title = "Thời gian bắt đầu", FieldName = "TimeStart", Width = 200)]
    [TableColumn(Title = "Thời gian kết thúc", FieldName = "TimeEnd", Width = 200)]
    [TableColumn(Title = "Trạng thái hợp đồng", FieldName = "ContractStatus", Width = 200)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note", Width = 75)]

    public class FormContract : ManageModule<ContractService, ContractModel, FormUpdateContract>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public long ContractCode { get; set; }
        #endregion

 
        public FormContract(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hợp đồng";
        }

        //public CommonServiceModel getService(long Id)
        //{
        ////    return this.commonService.Select(p => p.Id == Id).FirstOrDefault();
        //}
    }
}
