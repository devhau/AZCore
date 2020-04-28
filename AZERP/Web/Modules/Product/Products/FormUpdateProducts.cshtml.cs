using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

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

        public override IView Validate(ProductModel model, bool isNew)
        {
            if (model.RetailPrice < 0 || model.WholesalePrice < 0 || model.ImportPrice < 0)
            {
                return Json("Không được nhập giá âm", System.Net.HttpStatusCode.BadRequest);
            }
            return null;
        }
    }
}
