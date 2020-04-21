using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AZERP.Web.Modules.Product.StockAdjustments
{
    public class FormUpdateStockAdj : UpdateModule<StockAdjusmentService, StockAdjusmentModel, FormStockAdjustments>
    {
        public FormUpdateStockAdj(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Thêm/Sửa đơn kiểm hàng";
        }
        public override IView Post(long? Id, StockAdjusmentModel DataForm)
        {
            this.Service.BeginTransaction();
            try
            {
                DataFormToData(DataForm);

                DataForm.CreateAt = DateTime.Now;
                DataForm.CreateBy = User.Id;
                var id = Service.Insert(DataForm);
              
                foreach (StockAdjusmentModel model in this.ManagerForm.DataStock)
                {
                    model.ProductCode = id; ;
                }

                if (this.Service.InsertRange(this.ManagerForm.DataStock) > 0)
                {
                    this.Service.Commit();
                    return Json("Tao thanh cong");
                }
            }
            catch
            {
            }
            this.Service.Rollback();
            return Json("Khong thanh cong");

        }
    }
}
