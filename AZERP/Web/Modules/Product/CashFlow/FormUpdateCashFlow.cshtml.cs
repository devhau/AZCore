using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZERP.Data.Entities;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZERP.Web.Modules.Product.CashFlow
{
    public class FormUpdateCashFlow : UpdateModule<CashFlowService, CashFlowModel>
    {
        public FormUpdateCashFlow(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
    }
}
