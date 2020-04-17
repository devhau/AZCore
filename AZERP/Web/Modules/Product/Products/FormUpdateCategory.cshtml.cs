using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;


namespace AZERP.Web.Modules.Product.Products
{
    public class FormUpdateCategory : UpdateModule<CategoryService, CategoryModel>
    {
        public FormUpdateCategory(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa nhóm";
        }
    }
}
