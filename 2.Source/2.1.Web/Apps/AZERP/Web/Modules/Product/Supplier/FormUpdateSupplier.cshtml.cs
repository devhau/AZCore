using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.Supplier
{
    public class FormUpdateSupplier : UpdateModule<SupplierService, SupplierModel>
    {
        public FormUpdateSupplier(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa nhà cung cấp";
        }
    }
}
