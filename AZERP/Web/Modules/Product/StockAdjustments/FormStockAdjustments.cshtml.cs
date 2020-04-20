using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Product.StockAdjustments
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    public class FormStockAdjustments : ManageModule<StockAdjusmentService, StockAdjusmentModel, FormUpdateStockAdj>
    {
        ProductService productService;
        public FormStockAdjustments(IHttpContextAccessor httpContext, ProductService productService) : base(httpContext)
        {
            this.productService = productService;
        }
        protected override void IntData()
        {
            this.Title = "Kiểm hàng";
        }
        public IView GetProducbyid(long Id)
        {

            var result = productService.Select(p => p.Id == Id).FirstOrDefault();
            if (result != null)
            {
                return Json("", result);
            }
            else
            {
                return Json("");
            }
        }
    }
}
