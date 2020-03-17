using AZ.Web.Entities;
using AZWeb.Common.Manager;
using Microsoft.AspNetCore.Http;

namespace AZ.Web.Modules.Candidate
{
    public class FormCandidate : ManageModule<CandidateService, CandidateModel, FormUpdateCandidate>
    {
        public FormCandidate(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
        }
    }
}
