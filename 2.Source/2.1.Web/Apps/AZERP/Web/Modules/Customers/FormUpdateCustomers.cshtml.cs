using AZERP.Data.Entities;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Customers
{
    public class FormUpdateCustomers : UpdateModule<CustomersService, CustomersModel>
    {
        [BindService]
        public IGenCodeService getGenCode;

        public FormUpdateCustomers(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        protected override void IntData()
        {
            this.Title = "Khách hàng";
        }

       

    }
}
