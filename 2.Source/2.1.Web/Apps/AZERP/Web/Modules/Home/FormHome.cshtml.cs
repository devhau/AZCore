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
        public List<JobInfoModel> jobInfos;
        public FormHome(IHttpContextAccessor httpContext) : base(httpContext)
        {
            this.ThemeName = "JobF";
        }
        protected override void IntData()
        {
            this.Title = "Trang chủ - thông tin tuyển dụng JobF";
            jobInfos = jobInfoService.GetAll().ToList();
            base.IntData();
        }
        public IView Get(){
           return View();
        }
    }
}
