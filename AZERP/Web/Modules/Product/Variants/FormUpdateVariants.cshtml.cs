using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.Variants
{
    public class FormUpdateVariants : UpdateModule<ProductService, ProductModel>
    {
        public FormUpdateVariants(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa sản phẩm";
        }
    }
}
