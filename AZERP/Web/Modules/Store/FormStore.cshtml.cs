using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Store
{
    [TableColumn(Title = "Tên Kho", FieldName = "Name")]
    [TableColumn(Title = "Tên viết tắt", FieldName = "AbbreviatedName")]
    [TableColumn(Title = "Địa chỉ", FieldName = "Address")]
    [TableColumn(Title = "Số điện thoại", FieldName = "PhoneNumber")]
    [TableColumn(Title = "Mô tả", FieldName = "Description")]
    public class FormStore : ManageModule<StoreService, StoreModel, FormUpdateStore>
    {
        #region -- Field Search --
        /// <summary>
        /// Tên Kho
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Tên viết tắt
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string AbbreviatedName { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string PhoneNumber { get; set; }
        #endregion

        public FormStore(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý kho";
        }
    }
}
