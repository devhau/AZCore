using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AZERP.Web.Modules.Common.SystemCode
{
    public class FormUpdateSystemCode : UpdateModule<SystemCodeService, SystemCodeModel>
    {
        public FormUpdateSystemCode(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý mã code";
        }
        public override IView Vaildate(SystemCodeModel model, bool isNew)
        {
            if (isNew) {
                if (this.TenantId == null)
                {
                    if (this.Service.Select(p => p.Key == model.Key).Count() > 0)
                    {
                        return Json("Đã tồn tại key này rồi.<br/>vui lòng chọn key khác.", System.Net.HttpStatusCode.BadRequest);
                    }
                }
                else {
                    if (this.Service.Select(p => p.Key == model.Key && p.TenantId==this.TenantId).Count() > 0)
                    {
                        return Json("Đã tồn tại key này rồi.<br/>vui lòng chọn key khác.", System.Net.HttpStatusCode.BadRequest);
                    }
                }
            }
            return null;
        }

    }
}
