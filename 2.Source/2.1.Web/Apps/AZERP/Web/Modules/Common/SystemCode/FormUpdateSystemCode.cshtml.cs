using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Common.SystemCode
{
    public class FormUpdateSystemCode : UpdateModule<SystemCodeService, SystemCodeModel>
    {
        public FormUpdateSystemCode(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void AfterGet()
        {
            this.Title = IsNew?"Thêm mã code":"Cập nhật mã code";
        }
        public override void Validate(SystemCodeModel model, bool isNew)
        {
            if (isNew) {
                if (this.TenantId == null)
                {
                    if (this.Service.Select(p => p.Name == model.Name).Count() > 0)
                    {
                        throw new Exception("Đã tồn tại key này rồi.<br/>vui lòng chọn key khác.");
                    }
                }
                else {
                    if (this.Service.Select(p => p.Name == model.Name ).Count() > 0)
                    {
                        throw new Exception("Đã tồn tại key này rồi.<br/>vui lòng chọn key khác.");
                    }
                }
            }
        }

    }
}
