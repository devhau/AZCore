using AZCore.Database;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Common.Auth
{
    public class FormTenantRegister : PageModule
    {
        public string Domain { get; set; } = ".onsof.vn";
        public string Error { get; set; }
        public FormTenantRegister(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }
        protected override void IntData()
        {
            this.LayoutTheme = "Fullscreen";
            this.Title = "Thiết lập cửa hàng mới";
            base.IntData();
        }
        [BindService]
        public EntityTransaction EntityTransaction { get; set; }
        [BindForm(FromName = "Tenant")]
        public TenantModel TenantModel { get; set; }
        public IView Get()
        {

            if (this.IsAuth)
            {
                TenantModel = new TenantModel();
                TenantModel.Name = this.User.FullName;
                TenantModel.Email = this.User.Email;
                TenantModel.Phone = this.User.PhoneNumber;
            }
            return View();
        }
        public IView Post([BindForm] UserModel User)
        {
            var rs = false;
            if (User == null && this.IsAuth)
            {
                rs = EntityTransaction.DoTransantion<TenantService, TenantUserService>((p, p1, p2) =>
                {

                    var CanonicalName = TenantModel.CanonicalName.ToUrlSlug().ToLower();
                    if (p1.Select(p => p.CanonicalName == CanonicalName).Count() > 0)
                    {
                        throw new Exception(string.Format("{0} đã tồn tại rồi", TenantModel.CanonicalName));
                    }
                    long UserId = this.User.Id;
                    TenantModel.Status = EntityStatus.Active;
                    TenantModel.CanonicalName = CanonicalName;
                    TenantModel.CreateAt = DateTime.Now;
                    TenantModel.CreateBy = UserId;
                    var TenantId = p1.Insert(TenantModel);
                    p2.Insert(new TenantUserModel()
                    {
                        UserId = UserId,
                        TenantId = TenantId,
                        Status = AZCore.Identity.TenantUserStatus.Active,
                        IsAdmin = true,
                        CreateBy = UserId,
                        CreateAt = DateTime.Now
                    });

                });
            }
            else
            {

                rs = EntityTransaction.DoTransantion<TenantService, UserService, TenantUserService>((p, p1, p2, p3) =>
                {
                    var CanonicalName = TenantModel.CanonicalName.ToUrlSlug().ToLower();
                    if (p1.Select(p => p.CanonicalName == CanonicalName).Count() > 0)
                    {
                        throw new Exception(string.Format("Cửa hàng {0} đã được đăng ký rồi", TenantModel.CanonicalName));
                    }
                    if (p2.ExecuteNoneQuery(p => { p.AddWhere("Email", TenantModel.Email); p.SetColumn("count(0)"); }) > 0)
                    {
                        throw new Exception(string.Format("Mail {0} đã được người khác đăng ký rồi", TenantModel.Email));
                    }
                    if (p2.ExecuteNoneQuery(p => { p.AddWhere("PhoneNumber", TenantModel.Phone); p.SetColumn("count(0)"); }) > 0)
                    {
                        throw new Exception(string.Format("Số {0} đã được người khác đăng ký rồi!", TenantModel.Phone));
                    }
                    User.FullName = TenantModel.Name;
                    User.Email = TenantModel.Email;
                    User.PhoneNumber = TenantModel.Phone;
                    User.SetPassword(User.Password);
                    User.Status = EntityStatus.Active;
                    var UserId = p2.Insert(User);
                    TenantModel.Status = EntityStatus.Active;
                    TenantModel.CanonicalName = CanonicalName;
                    TenantModel.CreateAt = DateTime.Now;
                    TenantModel.CreateBy = UserId;

                    var TenantId = p1.Insert(TenantModel);
                    p3.Insert(new TenantUserModel()
                    {
                        UserId = UserId,
                        TenantId = TenantId,
                        Status = AZCore.Identity.TenantUserStatus.Active,
                        IsAdmin = true,
                        CreateBy = UserId,
                        CreateAt = DateTime.Now
                    });
                });
            }
            if (rs)
                return GoToRedirect(string.Format("https://{0}.{1}", TenantModel.CanonicalName, this.HttpContext.Request.Host.Value));
            this.Error = this.EntityTransaction.ErrorMessge;
            return View();
        }
    }
}
