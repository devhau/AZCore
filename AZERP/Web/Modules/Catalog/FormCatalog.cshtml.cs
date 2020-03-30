using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Catalog
{
    [TableColumn(Title = "Code", FieldName = "Code", Width = "150px")]
    [TableColumn(Title = "Nhóm", FieldName = "Name", Width = "")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", Width = "")]
    [TableColumn(Title = "Trạng thái", FieldName = "IsActive", Width = "150px")]
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
