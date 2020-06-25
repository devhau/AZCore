using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.Job
{
    public class FormUpdateJob : UpdateModule<JobInfoService, JobInfoModel>
    {
        public FormUpdateJob(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = this.IsNew? "Đăng bài việc làm mới":"Cập nhật việc làm";
        }

    }
}
