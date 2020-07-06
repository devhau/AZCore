using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZERP.Web.Modules.Home
{
    public class FormHome:PageModule
    {
        [BindService]
        public JobInfoService jobInfoService { get; set; }
        public List<JobInfoModel> jobNew;
        public List<JobInfoModel> jobHot;
        public List<JobInfoModel> jobPin;
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        protected override void IntData()
        {
            this.Title = "Trang chủ - thông tin tuyển dụng JobF";
            jobNew = jobInfoService.GetAll().ToList();
            jobHot = jobInfoService.GetAll().ToList();
            jobPin = jobInfoService.GetAll().ToList();
            base.IntData();
        }
        public IView Get(){
           return View();
        }
        [OnlyAjax]
        public IView GetApplyJobForm(long JobId)
        {
            this.Title = "Đăng ký thông tin ứng tuyển vị trí này";
            
            return View("Component/ApplyJobForm", jobInfoService.GetById(JobId));
        }
        [OnlyAjax]
        public IView PostApplyJobForm(long JobId)
        {
            

            return Json("Chúng tôi đã tiếp nhận thôn tin của bạn.<br/>Chúng tôi sẽ liên hệ sớm cho bạn");
        }
    }
}
