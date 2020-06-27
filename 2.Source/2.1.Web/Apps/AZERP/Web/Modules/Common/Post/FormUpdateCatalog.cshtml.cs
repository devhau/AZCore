using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Common.Post
{
    public class FormUpdateCatalog : UpdateModule<CatalogService, CatalogModel>
    {
        public FormUpdateCatalog(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void AfterGet()
        {
            this.Title = this.IsNew? "Thêm nhóm bài viết":"Cập nhật nhóm bài viết";
        }

    }
}
