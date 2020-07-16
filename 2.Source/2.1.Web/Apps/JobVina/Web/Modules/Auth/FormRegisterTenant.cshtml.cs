using AZCore.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JobVina.Web.Modules.Auth
{
    public class FormRegisterTenant : PageHome
    {
        public FormRegisterTenant(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.IsTheme = false;
        }

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
            entityTransaction.DoTransantion<UserService, TenantService>((T,userService, tenantService)=> {

                var user = new UserModel()
                {
                    FullName = InputFullName,
                    PhoneNumber = InputPhoneNumber,
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

                }

            });
            return GoToAuth(false);
        }
    }
}
