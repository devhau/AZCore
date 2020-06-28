using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormContent : PageModule
    {
        [BindService]
        public PostService postService { get; set; }
        [BindQuery]
        public long PostId { get; set; }
        public PostModel postModel;
        public FormContent(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        protected override void IntData()
        {
            this.Title = "Trang chủ - thông tin tuyển dụng JobF";
            base.IntData();
        }
        public IView Get(){
            postModel = this.postService.GetById(this.PostId);
            this.Title = postModel.Title;
            this.Description = postModel.Description;
           return View();
        }
    }
}
