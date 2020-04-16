using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.Products
{
    public class FormUpdateProducts : UpdateModule<ProductService, ProductModel>
    {
        public FormUpdateProducts(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa sản phẩm";
        }
    }
}
