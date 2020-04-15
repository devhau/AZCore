using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Bill
{
    public class FormUpdateProduct : UpdateModule<ProductService, ProductModel>
    {
        public FormUpdateProduct(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa sản phẩm";
        }
    }
}
