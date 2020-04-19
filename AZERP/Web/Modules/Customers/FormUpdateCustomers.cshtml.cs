using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Customers
{
    public class FormUpdateCustomers : UpdateModule<CustomersService, CustomersModel>
    {
        public FormUpdateCustomers(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Khách hàng";
        }

    }
}
