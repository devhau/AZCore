using AZCore.Database.Attributes;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using AZWeb.Module.TagHelper.Module;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pe = AZERP.Web.Permissions.Permission;
namespace AZERP.Web.Modules.Common.Permission
{
    [TableColumn(Title = "Key", FieldName = "Key", Width = 200)]
    [TableColumn(Title = "Mã quyền", FieldName = "Code", Width = 150)]
    [TableColumn(Title = "Quyền", FieldName = "Name")]
    public class FormPermission : ManageModule<PermissionService, PermissionModel>
    {
        public ViewPermission dataView;

        #region --- Service ---
        [BindService]
        public UserPermissionService UserPermissionService { get; set; }
        [BindService]
        public RolePermissionService RolePermissionService { get; set; }
        [BindService]
        public UserRoleService UserRoleService;
        #endregion

        protected override IEnumerable<ButtonInfo> CreateButtons()
        {           
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-info btn-sm az-btn az-btn-export",
                CMD = "f2",
                PermisisonCode = this.ModuleInfo?.ExportCode,
                Icon = "fas fa-file-export",
                Text = "Xuất Excel (F2)"
            };
            yield return new ButtonInfo()
            {
                ClassName = "btn btn-secondary btn-sm az-btn az-btn-update-permission",
                CMD = "f3",
                PermisisonCode = this.ModuleInfo?.ImportCode,
                Icon = "fas fa-file-import",
                Text = "Cập nhật quyền (F3)"
            };
            yield return new ButtonInfo()
            {
                Link= "/vai-tro.az",
                ClassName = "btn btn-success btn-sm az-btn az-btn-add az-link-popup",
                CMD = "f4",
                PermisisonCode = this.ModuleInfo?.AddCode,
                Icon = "fas fa-user-tag",
                ModalSize= "az-modal-xl",
                Text = "Quản lý vai trò (F4)"
            };
            yield return new ButtonInfo()
            {
                Link = "/danh-sach-quyen.az?h=User",
                ClassName = "btn btn-danger btn-sm az-btn az-btn-add az-link-popup",
                CMD = "f4",
                PermisisonCode = this.ModuleInfo?.AddCode,
                Icon = "fas fa-user-tag",
                ModalSize = "az-modal-xl",
                Text = "Phân quyền cho người dùng (F5)"
            };
        }
        public FormPermission(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Danh sách quyền hệ thống";
        }
        [BindQuery]
        public long UserId { get; set; }
        [BindQuery]
        public long RoleId { get; set; }
        public List<long> Roles { get; set; }
        [OnlyAjax]
        public IView GetUser()
        {
            this.Title = "Phân quyền cho người dùng";
            dataView = new ViewPermission();
            if (UserId > 0) {
                dataView.Permissions = this.Service.GetAll().ToList();
                dataView.PermissionActive = UserPermissionService.Select(p => p.UserId == this.UserId).Select(p => p.PermissionCode).ToList();
                this.Roles = this.UserRoleService.Select(p => p.UserId == this.UserId).Select(p => p.RoleId).ToList();
            }
            return View("UserPermission");
        }
        [OnlyAjax]
        public IView PutUser(long code, bool flg) {
            if (flg) {
                if (!UserRoleService.Select(p => p.UserId == UserId && p.RoleId == code).Any())
                {
                    UserRoleService.Insert(new UserRoleModel()
                    {
                        UserId = UserId,
                        RoleId = code
                    });
                }
            }
            else
            {
                UserRoleService.Delete(p => p.RoleId == code && p.UserId == UserId);
            }
            return Json("Cập nhật vai trò thành công");
        }
        [OnlyAjax]
        public IView PostUser(string code,string Codes, bool flg)
        {
            if (string.IsNullOrEmpty(Codes) && !string.IsNullOrEmpty(code))
            {
                if (flg)
                {
                    if (!UserPermissionService.Select(p => p.UserId == UserId && p.PermissionCode == code).Any())
                    {
                        UserPermissionService.Insert(new UserPermissionModel()
                        {
                            UserId = UserId,
                            PermissionCode = code
                        });
                    }
                }
                else
                {
                    UserPermissionService.Delete(p => p.PermissionCode == code && p.UserId == UserId);
                }
            }
            else {
                if (Codes == null) return Json("Không thể thay đổi quyền",System.Net.HttpStatusCode.BadRequest);
                foreach (var item in Codes.Split(','))
                {
                    if (flg)
                    {
                        if (!UserPermissionService.Select(p => p.UserId == UserId && p.PermissionCode == item).Any())
                        {
                            UserPermissionService.Insert(new UserPermissionModel()
                            {
                                UserId = UserId,
                                PermissionCode = item
                            });
                        }
                    }
                    else
                    {
                        UserPermissionService.Delete(p => p.UserId == UserId && p.PermissionCode == item );
                    }
                }
            }
           
            return Json("Cập nhật quyền thành công");
        }
        [OnlyAjax]
        public IView GetRole()
        {
            this.Title = "Phân quyền cho vai trò";
            dataView = new ViewPermission();
            if (RoleId > 0) {             
                dataView.Permissions = this.Service.GetAll().ToList();
                dataView.PermissionActive = this.RolePermissionService.Select(p => p.RoleId == this.RoleId).Select(p => p.PermissionCode).ToList();
            }
            return View("RolePermission");
        }
        [OnlyAjax]
        public IView PostRole(string code, string Codes, bool flg)
        {
            if (string.IsNullOrEmpty(Codes) && !string.IsNullOrEmpty(code))
            {
                if (flg)
                {
                    if (RolePermissionService.Select(p => p.RoleId == RoleId && p.PermissionCode == code).Count() == 0)
                    {
                        RolePermissionService.Insert(new RolePermissionModel()
                        {
                            RoleId = RoleId,
                            PermissionCode = code
                        });
                    }
                }
                else
                {
                    RolePermissionService.Delete(p => p.PermissionCode == code && p.RoleId == RoleId);
                }
            }
            else
            {
                Codes = Codes.Trim(',');
                foreach (var item in Codes.Split(','))
                {
                    if (flg)
                    {
                        if (!RolePermissionService.Select(p => p.RoleId == RoleId && p.PermissionCode == item).Any())
                        {
                            RolePermissionService.Insert(new RolePermissionModel()
                            {
                                RoleId = RoleId,
                                PermissionCode = item
                            });
                        }
                    }
                    else
                    {
                        RolePermissionService.Delete(p => p.RoleId == RoleId && p.PermissionCode == item);
                    }
                }
            }

            return Json("Cập nhật quyền thành công");
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
                        Name = dis.Display
                    });
            }
            return Json("cập nhật danh sách quyền thành công");
        }
    }
}
