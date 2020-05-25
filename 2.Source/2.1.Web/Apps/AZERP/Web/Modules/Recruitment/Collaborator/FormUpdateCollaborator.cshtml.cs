using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Recruitment.Collaborator
{
    public class FormUpdateCollaborator : UpdateModule<CollaboratorService, CollaboratorModel>
    {
        public FormUpdateCollaborator(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Cộng tác viên";
        }

    }
}
