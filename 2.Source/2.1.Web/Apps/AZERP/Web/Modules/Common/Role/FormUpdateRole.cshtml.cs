using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Common.Role
{
    public class FormUpdateRole : UpdateModule<RoleService, RoleModel>
    {
        public FormUpdateRole(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void AfterGet()
        {
            this.Title = IsNew ?"Thêm vai trò":"Cập nhật vai trò";
        }

    }
}
