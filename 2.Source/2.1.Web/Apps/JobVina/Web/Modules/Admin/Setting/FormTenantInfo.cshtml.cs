using AZWeb.Extensions;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using JobVina.Common;
using JobVina.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace JobVina.Web.Modules.Admin.Setting
{
    public class FormTenantInfo : PageAdmin
    {
        public FormTenantInfo(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            this.Title = "Thiết lập đơn vị cung ứng lao động";
        }
        [BindService]
        public TenantService TenantService;
        public IView Get()
        {
            return View(this.TenantService.GetById(this.User.TenantId));
        }
        public IView Post() {
            var model = this.TenantService.GetById(this.User.TenantId);
            this.HttpContext.BindFormTo(model);
            model.UpdateAt = DateTime.Now;
            model.UpdateBy = this.User.Id;
            this.TenantService.Update(model);
            this.AddJS("alert('Cập nhật thành công')");
            return View(model);
        }
    }
}
