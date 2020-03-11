using AZ.Web.Entities;
using AZWeb.Common.Module;
using AZWeb.Common.Module.View;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace AZ.Web.Modules.Candidate
{
    public class FormCandidate: PageModule
    {
        CandidateService candidateService;
        public List<CandidateModel> DataList { get; set; }
        private FormUpdateCandidate updateForm { get; set; }
        public FormCandidate(IHttpContextAccessor httpContext, CandidateService _candidateService) : base(httpContext)
        {
            this.candidateService = _candidateService;
            this.updateForm = new FormUpdateCandidate(httpContext, _candidateService);
        }
        protected override void IntData()
        {
            this.Title = "Quản lý ứng viên";
            DataList = candidateService.GetAll().ToList();
        }
        public IView GetUpdate(object Id)
        {
            return this.updateForm.Get(Id);
        }
        public  IView Get(object[] Id)
        {
            return View();
        }
       
    }
}
