using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Home
{
    public class FormBlogs : PageModule
    {
        [BindService]
        public PostService postService { get; set; }
        [BindQuery]
        public long? CatalogId { get; set; }
        [BindQuery] 
        public int PageIndex { get; set; } = 1;
        public List<PostModel> posts;
        public FormBlogs(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        public IView Get()
        {
            this.Title = "Bài viết mới";
            posts = postService.ExecuteQuery(item =>
            {
                item.Pagination((PageIndex > 0 ? PageIndex : 1), 10);
                if (this.CatalogId != null && this.CatalogId > 0)
                {
                    item.AddWhere("CatalogId", CatalogId);
                }
            }).ToList();
            
            return View();
        }
    }
}
