using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product
{
    public class FormUpdateProduct : UpdateModule<ProductService, ProductModel>
    {
        public FormUpdateProduct(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý sản phẩm";
        }
    }
}
