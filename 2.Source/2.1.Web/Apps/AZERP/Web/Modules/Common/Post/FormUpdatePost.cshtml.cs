using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Common.Post
{
    public class FormUpdatePost : UpdateModule<PostService, PostModel>
    {
        public FormUpdatePost(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void AfterGet()
        {
            this.Title = this.IsNew ? "Thêm bài viết" : "Cập nhật bài viết";
        }

    }
}
