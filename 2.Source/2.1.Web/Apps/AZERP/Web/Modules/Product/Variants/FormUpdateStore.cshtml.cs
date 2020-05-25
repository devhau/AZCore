using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.Variants
{
    public class FormUpdateStore : UpdateModule<StoreService, StoreModel>
    {
        public FormUpdateStore(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Cập nhật kho";
        }
    }
}
