using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Pe = AZERP.Web.Permissions.Permission;
namespace AZERP.Web.Modules.Common.Permission
{
    [TableColumn(Title = "Mã quyền", FieldName = "Code", Width = 150)]
    [TableColumn(Title = "Quyền", FieldName = "Name")]
    [TableColumn(Title = "Trạng thái", FieldName = "Status", Width = 150 ,DataType =typeof(EntityStatus))]
    public class FormPermission : ManageModule<PermissionService, PermissionModel, FormUpdatePermission>
    {
        public FormPermission(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách quyền hệ thống";
        }
        public IView GetPermission() {
            var pes = new List<PermissionModel>();
            var files=typeof(Pe).GetFields();
            foreach (var item in typeof(Pe).GetFields()) {
                var dis = item.GetAttribute<FieldAttribute>();
                pes.Add(new PermissionModel()
                {
                    Key = item.Name,
                    Code = string.Format("{0}", item.GetRawConstantValue()),
                    Name = dis.Display
                }) ;
            }
            return View();
        }
    }
}
