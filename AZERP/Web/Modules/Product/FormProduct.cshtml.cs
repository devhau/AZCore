using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Attribute;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Product
{
    [TableColumn(Title = "Code", FieldName = "Code", Width = 70,IsQRCode =true)]
    [TableColumn(Title = "Nhóm", FieldName = "Name",DataType =typeof(CatalogService))]
    [TableColumn(Title = "Giá Bán", FieldName = "Price",FormatString ="{0:n3} VND")]
    public class FormProduct : ManageModule<ProductService, ProductModel, FormUpdateProduct>
    {
        public FormProduct(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Quản lý sản phẩm";
        }
    }
}
