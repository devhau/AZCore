using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Catalog
{
    [TableColumn(Title = "Code", FieldName = "Code", Width = "70px",IsQRCode =true)]
    [TableColumn(Title = "Nhóm", FieldName = "Name", Width = "")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", Width = "", DataType =typeof(CatalogService))]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = "150px" ,DataType =typeof(EntityStatus))]
    public class FormCatalog : ManageModule<CatalogService, CatalogModel, FormUpdateCatalog>
    {
        public FormCatalog(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý nhóm sản phẩm";
        }
    }
}
