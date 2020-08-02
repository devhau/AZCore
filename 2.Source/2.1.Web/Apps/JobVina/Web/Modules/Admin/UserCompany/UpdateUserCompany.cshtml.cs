using AZWeb.Module.Attributes;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace JobVina.Web.Modules.Admin.UserCompany
{
    public class UpdateUserCompany : PageUpdate<UserService,UserModel>
    {
        [BindService]
        public TenantUserService TenantUserService { get; set; }
        public UpdateUserCompany(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            
        }
        protected override void AfterGet()
        {
            if (this.IsNew)
            {
                this.Title = "Thêm mới nhân viên mới";
            }
            else
                this.Title = "Cập nhật nhân viên: " + this.Data.FullName;
        }
        public override void BeforeInsert(UserModel DataForm)
        {
            DataForm.IsTenant = true;
            base.BeforeInsert(DataForm);
        }
        public override void AfterInsert(UserModel DataForm)
        {
            TenantUserService.Insert(new TenantUserModel()
            {
                Status=AZCore.Identity.TenantUserStatus.Invite,
                UserId=DataForm.Id,
                TenantId=this.TenantId,
                CreateAt=DateTime.Now,
                CreateBy=this.User.Id
            });
            base.AfterInsert(DataForm);
        }
    }
}
