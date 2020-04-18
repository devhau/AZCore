using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Pe = AZERP.Web.Permissions.Permission;
namespace AZERP.Web.Modules.Common.Permission
{
    [TableColumn(Title = "Key", FieldName = "Key", Width = 200)]
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
        [OnlyAjax]
        public IView GetUser(long Id)
        {
            this.Title = "Phân quyền cho người dùng";
            var viewPer = new ViewPermission();
            viewPer.Permissions = this.GetSearchData(); 
            viewPer.PermissionActive = null;
            return View("ViewPermission");
        }
        [OnlyAjax]
        public IView GetRole(long Id)
        {
            this.Title = "Phân quyền cho vai trò";
            var viewPer = new ViewPermission();
            viewPer.Permissions = this.GetSearchData();
            viewPer.PermissionActive = null;
            return View("ViewPermission", viewPer);
        }
        [OnlyAjax]
        public async Task<IView> PostPermission() {
           await this.Service.DeleteAll();
            var files=typeof(Pe).GetFields();
            foreach (var item in typeof(Pe).GetFields().OrderBy(p=>p.GetAttribute<FieldAttribute>().OrderIndex).ToList()) {
                var dis = item.GetAttribute<FieldAttribute>();
                this.Service.Insert(
                    new PermissionModel()
                    {
                        Key = item.Name,
                        Code = string.Format("{0}", item.GetRawConstantValue()),
                        Name = dis.Display,
                        Status=EntityStatus.Active,
                        CreateAt = DateTime.Now,
                        CreateBy = this.User.Id
                    });
            }
            
            return Json("cập nhật danh sách quyền thành công");
        }
    }
}
