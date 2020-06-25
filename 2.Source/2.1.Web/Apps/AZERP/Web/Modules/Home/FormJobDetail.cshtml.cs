using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Home
{
    public class FormJobDetail : PageModule
    {
        [BindService]
        public JobInfoService jobInfoService { get; set; }
        public JobInfoModel jobInfo;
        [BindQuery]
        public long JobId { get; set; }

        public FormJobDetail(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        protected override void IntData()
        {
            this.Title = "Trang chủ - thông tin tuyển dụng JobF";
            this.jobInfo = jobInfoService.GetById(this.JobId);
            base.IntData();
        }
        public IView Get(){
           return View();
        }
    }
}
