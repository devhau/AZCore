using AZCore.Database;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attribute;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.CompanyWorker
{
    [TableColumn(Title = "Tên công ty", FieldName = "Name")]
    [TableColumn(Title = "Tên viết tắt", FieldName = "AbbreviatedName")]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address", Width = 250)]
    [TableColumn(Title = "Khu vực", FieldName = "AtAddress", Width = 150, DataType = typeof(EnumAddressWorker))]
    [TableColumn(Title = "Mô tả", FieldName = "Description")]
    public class FormCompanyWorker : ManageModule<CompanyWorkerService, CompanyWorkerModel, FormUpdateCompanyWorker>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên công ty
        /// </summary>
        [QuerySearch(OperatorSQL = EnumOperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Tên viết tắt
        /// </summary>
        [QuerySearch(OperatorSQL = EnumOperatorSQL.LIKE)]
        public string AbbreviatedName { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch(OperatorSQL = EnumOperatorSQL.LIKE)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [QuerySearch(OperatorSQL = EnumOperatorSQL.LIKE)]
        public string Address { get; set; }
        /// <summary>
        /// Công ty ở khu vực nào
        /// </summary>
        [QuerySearch]
        public EnumAddressWorker? AtAddress { get; set; }
        #endregion

        public FormCompanyWorker(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý công ty thuê công nhân";
        }
    }
}
