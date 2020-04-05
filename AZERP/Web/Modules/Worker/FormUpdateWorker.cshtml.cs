using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Worker
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
