using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.Candidate
{
    public class FormUpdateCandidate : UpdateModule<CandidateService, CandidateModel>
    {
        public FormUpdateCandidate(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }

    }
}
