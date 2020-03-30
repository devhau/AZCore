using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Catalog
{
    public class FormUpdateCatalog : UpdateModule<CatalogService, CatalogModel>
    {
        public FormUpdateCatalog(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }

    }
}
