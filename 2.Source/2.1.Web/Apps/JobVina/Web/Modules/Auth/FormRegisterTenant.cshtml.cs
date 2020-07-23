using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace JobVina.Web.Modules.Auth
{
    public class FormRegisterTenant : PageHome
    {
        public FormRegisterTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.IsTheme = false;
        }
        [BindQuery]
        public string JoinCode { get; set; }
        public string MessageError { get; set; }
        [BindService]
        public AZCore.Database.EntityTransaction entityTransaction;
        public IView Get()
        {
            return View();
        }
        public IView Post([BindForm] string InputFullName, [BindForm] string InputEmail, [BindForm] string InputPhoneNumber, [BindForm] string InputPassword,[BindForm]bool InputCheckTentaint,[BindForm]string InputTentaintName, [BindForm] string terms)
        {
            if (InputFullName.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập họ tên";
                return View();
            }
            if (InputEmail.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập địa chỉ email";
                return View();
            }
            if (InputPhoneNumber.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập số điện thoại";
                return View();
            }           
            if (InputPassword.IsNullOrEmpty())
            {
                MessageError = "Vui lòng nhập mật khẩu";
                return View();
            }
            if (InputTentaintName.IsNullOrEmpty())
            {
                MessageError = InputCheckTentaint?"Vui lòng nhập mã đơn vị":"Vui lòng nhập tên đơn vị";
                return View();
            }
            entityTransaction.DoTransantion<UserService, TenantService, TenantUserService>((T,userService, tenantService, tenantUserService) => {

                var user = new UserModel()
                {
                    FullName = InputFullName,
                    PhoneNumber = InputPhoneNumber,
                    Email=InputEmail,
                    Password = InputPassword,
                    IsTenant = true,
                    CreateBy = 0,
                    CreateAt = DateTime.Now,
                    Status = AZCore.Database.EntityStatus.Active
                };
                user.SetPassword();
                user.Id = userService.Insert(user);


                //Đã tồn tại
                if (InputCheckTentaint)
                {
                    var tenant = tenantService.ExecuteQuery(p => p.AddWhere("ConcurrencyStamp", InputTentaintName)).FirstOrDefault();
                    if (tenant == null)
                        throw new Exception("Đối tác không tồn tại");
                    tenantUserService.Insert(new TenantUserModel()
                    {
                        Status = AZCore.Identity.TenantUserStatus.Join,
                        UserId = user.Id,
                        TenantId = tenant.Id,
                        CreateAt = DateTime.Now,
                        CreateBy = user.Id,
                    });
                }
                else
                {
                    var tenant = new TenantModel()
                    {
                        Name = InputTentaintName,
                        CanonicalName = InputTentaintName,
                        Phone = InputPhoneNumber,
                        Email = InputEmail,
                        CreateBy = user.Id,
                        CreateAt = DateTime.Now,
                        Status = AZCore.Database.EntityStatus.Active
                    };
                    tenant.Id = tenantService.Insert(tenant);
                    tenantUserService.Insert(new TenantUserModel()
                    {
                        Status = AZCore.Identity.TenantUserStatus.Active,
                        IsAdmin = true,
                        UserId = user.Id,
                        TenantId = tenant.Id,
                        CreateAt = DateTime.Now,
                        CreateBy = user.Id,
                    });
                }
            });
            return GoToAuth(false);
        }
    }
}
