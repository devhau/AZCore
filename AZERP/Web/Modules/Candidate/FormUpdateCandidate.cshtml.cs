using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Candidate
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
