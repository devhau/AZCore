using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Common.Manager;
using AZWeb.Common.Module.Attr;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Role
{
    [TableColumn(Title = "Vai trò", FieldName = "Name")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 ,DataType =typeof(EntityStatus))]
    public class FormRole : ManageModule<RoleService, RoleModel, FormUpdateRole>
    {
        public FormRole(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý vai trò";
        }
    }
}
