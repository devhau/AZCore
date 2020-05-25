using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;

namespace AZERP.Web.Modules.Hotel.Contract { 
    public class FormUpdateContract : UpdateModule<ContractService, ContractModel>
    {
        public FormUpdateContract(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Hợp đồng";
        }

    }
}
