using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Common.Permission
{
    public class FormUpdatePermission : UpdateModule<PermissionService, PermissionModel>
    {
        public FormUpdatePermission(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quyền hệ thống";
        }

    }
}
