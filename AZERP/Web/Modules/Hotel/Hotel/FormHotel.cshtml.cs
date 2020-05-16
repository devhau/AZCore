using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Hotel
{
    [TableColumn(Title = "Mã phòng", FieldName = "HotelCode", Width = 100)]
    [TableColumn(Title = "Tên phòng", FieldName = "HotelName", Width = 100)]
    [TableColumn(Title = "Tên khu vực", FieldName = "AreaID", Width = 150, DataType = typeof(AreaService))]
    [TableColumn(Title = "Loại phòng trọ", FieldName = "TypeOfHotelID", Width = 150, DataType = typeof(TypeOfHotelService))]
    [TableColumn(Title = "Trạng thái", FieldName = "HotelStatus", Width = 200, DataType = typeof(HotelStatus))]
    [TableColumn(Title = "Tiền phòng", FieldName = "RoomCharge", FormatString = "{0:#,###}", Width = 200)]
    [TableColumn(Title = "Dịch vụ", LinkFormat = "danh-sach-phong-tro.az?h=Service&Id={Id}", Text = "Dịch vụ phòng", Popup = AZWeb.Module.Enums.PopupSize.Popup)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormHotel : ManageModule<HotelService, HotelModel, FormUpdateHotel>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string HotelName { get; set; }
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
        /// Trạng thái của phòng trọ
        /// </summary>
        [QuerySearch]
        public HotelStatus? HotelStatus { get; set; }
        [QuerySearch]
        public decimal? RoomCharge { get; set; }
        #endregion

        public FormHotel(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý phòng trọ";
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
