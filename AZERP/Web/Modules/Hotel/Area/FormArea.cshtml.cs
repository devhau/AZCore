using AZCore.Database.Enums;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Hotel.Area
{
    [TableColumn(Title = "Mã khu vực ", FieldName = "AreaID", Width = 100)]
    [TableColumn(Title = "Tên khu vực", FieldName = "AreaName", Width = 130)]
    [TableColumn(Title = "Dịch vụ", LinkFormat = "danh-sach-khu-vuc.az?h=Service&Id={AreaName}", Text = "Dịch vụ khu vực", Popup = AZWeb.Module.Enums.PopupSize.Large)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormArea : ManageModule<AreaService, AreaModel, FormUpdateArea>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string AreaName { get; set; }
        #endregion

        [BindService]
        public AZERP.Data.Entities.CommonService commonService;
        public List<AZERP.Data.Entities.RegionalServiceModel> ListDataService { get; set; }
        public AZERP.Data.Entities.RegionalServiceModel DataCurrent = null;
        private List<RegionalServiceModel> listDataOrder;
        public bool CanEdit = true;
        public FormArea(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý khu vực";
        }
        public IView GetService(string Id)
        {
            if (Id.IsNullOrEmpty())
            {

            }
            else
            {
                this.Title = "Dịch vụ khu vực " + Id;
            }
           
            return View("RegionalService");
        }
        public IView PostService(string Id)
        {
            this.Title = "Dịch vụ khu vực " + Id;
            return View("RegionalService");
        }

        public CommonServiceModel getService(long Id)
        {
            return this.commonService.Select(p => p.Id == Id).FirstOrDefault();
        }
    }
}
