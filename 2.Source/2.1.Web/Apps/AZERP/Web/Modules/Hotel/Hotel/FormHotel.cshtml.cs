using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Hotel
{
    [TableColumn(Title = "Mã phòng", FieldName = "Code", Width = 100)]
    [TableColumn(Title = "Tên phòng", FieldName = "Name", Width = 100)]
    [TableColumn(Title = "Khu vực/ tòa nhà", FieldName = "AreaID", Width = 250, DataType = typeof(AreaService))]
    [TableColumn(Title = "Tầng", FieldName = "FloorId", Width = 100)]
    [TableColumn(Title = "Loại phòng trọ", FieldName = "TypeOfHotelID", Width = 150, DataType = typeof(TypeOfHotelService))]
    [TableColumn(Title = "Trạng thái phòng", FieldName = "HotelStatus", Width = 200, DataType = typeof(HotelStatus))]
    [TableColumn(Title = "Tiền phòng", FieldName = "RoomCharge", FormatString = "{0:#,###}", Width = 150)]
    //[TableColumn(Title = "Dịch vụ", LinkFormat = "danh-sach-phong-tro.az?h=Service&Id={Id}", Text = "Dịch vụ phòng", Popup = AZWeb.Module.Enums.PopupSize.Popup)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormHotel : ManageModule<HotelService, HotelModel, FormUpdateHotel>
    {
       
        #region -- Field Search --
        /// <summary>
        /// Tên phòng trọ
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Loại phòng trọ
        /// </summary>
        [QuerySearch]
        public long? TypeOfHotelID { get; set; }
        /// <summary>
        /// Khu vực
        /// </summary>
        [QuerySearch]
        public long? AreaID { get; set; }
        /// <summary>
        /// Tầng
        /// </summary>
        [QuerySearch]
        public long? FloorId { get; set; }
        /// <summary>
        /// Trạng thái của phòng trọ
        /// </summary>
        [QuerySearch]
        public HotelStatus? HotelStatus { get; set; }
        /// <summary>
        /// Tiền phòng
        /// </summary>
        [QuerySearch]
        public decimal? RoomCharge { get; set; }
        #endregion

        public override List<HotelModel> GetSearchData()
        {
            return base.GetSearchData();
        }
        // ?tang=12
        [BindQuery(FromName ="tang")]
        public long? TangId { get;set; }


        public FormHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            //this.TenantId
            this.Title = "Danh sách phòng trọ";

        }
        public IView GetService(long Id)
        {
            this.Title = "Dịch vụ của phòng " + Id;
            return View("HotelService");
        }
        public IView PostService(long Id)
        {
            this.Title = "Dịch vụ của phòng " + Id;
            return View("HotelService");
        }


    }
}
