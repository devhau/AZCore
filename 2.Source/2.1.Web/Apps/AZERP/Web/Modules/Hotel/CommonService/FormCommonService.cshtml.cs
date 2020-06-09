using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.CommonService
{
    [TableColumn(Title = "Mã dịch vụ ", FieldName = "Code", Width = 180)]
    [TableColumn(Title = "Tên dịch vụ", FieldName = "Name", Width = 180)]
    [TableColumn(Title = "Ghi chú", FieldName = "Note")]

    public class FormCommonService : ManageModule<AZERP.Data.Entities.CommonService, CommonServiceModel, FormUpdateCommonService>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên khu vực
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        #endregion

        public FormCommonService(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách dịch vụ chung";
        }
    }
}
