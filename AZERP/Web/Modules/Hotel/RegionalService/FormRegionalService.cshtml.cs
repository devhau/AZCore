using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.RegionalService
{
    [TableColumn(Title = "Mã dịch vụ ", FieldName = "RegionalServiceID", Width = 180)]
    [TableColumn(Title = "Tên dịch vụ", FieldName = "CommonServiceID", Width = 180, DataType =typeof(AZERP.Data.Entities.CommonService))]
    [TableColumn(Title = "Đơn giá", FieldName = "Price", Width = 180)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormRegionalService : ManageModule<AZERP.Data.Entities.RegionalService, RegionalServiceModel, FormUpdateRegionalService>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string RegionalServiceName { get; set; }
        [QuerySearch]
        public decimal? Price { get; set; }
        #endregion

        public FormRegionalService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách dịch vụ khu vực";
        }
    }
}
