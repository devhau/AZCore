using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.Worker
{
    public class FormUpdateWorker : UpdateModule<WorkerService, WorkerModel>
    {
        public FormUpdateWorker(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý công nhân";
        }

    }
}
