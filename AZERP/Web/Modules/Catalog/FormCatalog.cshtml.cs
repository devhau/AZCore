using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Enums;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Catalog
{
    [TableColumn(Title = "Code", FieldName = "Code", Width = 70, Icon = "fas fa-qrcode az-qrcode",Display =DisplayColumn.Icon)]
    [TableColumn(Title = "Nhóm", FieldName = "Name")]
    [TableColumn(Title = "Nhóm cha", FieldName = "ParentId", DataType =typeof(CatalogService))]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 ,DataType =typeof(EntityStatus))]
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
