using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZCore.Database;
using AZERP.Data.Entities;
using AZWeb.Extensions;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using AZWeb.Module.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZERP.Web.Modules.Product.CashFlow
{
    [TableColumn(Title = "Mã Phiếu Thu", FieldName = "Code")]
    [TableColumn(Title = "Thời Gian", FieldName = "PaymentDate")]
    [TableColumn(Title = "Giá Trị Phiếu Thu", FieldName = "Money")]
    [TableColumn(Title = "Khách hàng", FieldName = "PartnerId", DataType = typeof(CustomersService))]
    [TableColumn(Title = "Đã Thu Trước", FieldName = "RealMoney", DataType = typeof(CashFlowOrdersService))]
    [TableColumn(Title = "Còn Cần Thu", FieldName = "RealMoney", DataType = typeof(CashFlowOrdersService))]
    [TableColumn(Title = "Tiền Thu", FieldName = "RealMoney", DataType = typeof(CashFlowOrdersService))]
    public class FormCashFlow : ManageModule<CashFlowService, CashFlowModel, FormUpdateCashFlow>
    {


        [BindService]
        public CustomersService CustomersService;
        [BindService]
        public OrderService OrderService;

        [BindService]
        public CashFlowOrdersService cashFlowDetailService;
        [BindService]
        public EntityTransaction entityTransaction;
        [BindService]
        public IGenCodeService genCodeService;

        [BindQuery]
        public long Id { get; set; }

        [BindForm]
        public List<CashFlowOrdersModel> ListCashDetailModel { get; set; }

        //public CashFlowModel Data;

        public CashFlowOrdersModel DataDetail;
        public CustomersModel CustomersModel;
        public OrderModel OrderModel;

        public bool CanEdit = true;
        public CashFlowModel DataCurrent = null;
        public long totalMoney;
        public FormCashFlow(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public void OnGet()
        {
        }

        protected override void IntData()
        {
            this.Title = "Phiếu Thu";
        }

        public override IView GetUpdate(long? Id)
        {
            if (Id == null || Id == 0)
            {
                // View Create Purchase Order
                this.Title = "Thêm mới Phiếu Thu";
                totalMoney = 10000;
            }
            else
            {
                // View Update Purchase Order
                DataCurrent = this.Service.GetById(Id);
                CustomersModel = this.CustomersService.Select(p => p.Id == DataCurrent.PartnerId).FirstOrDefault();
                ListCashDetailModel = this.cashFlowDetailService.Select(p => p.CashFlowId == DataCurrent.Id).ToList();
                //totalMoney = ListCashDetailModel.Select(p => p.RealMoney).Sum();
                this.Title = "Cập nhật Phiếu Thu (" + DataCurrent.Code + ")";

            }
            return View("FormUpdateCashFlow");
        }

        public override IView PostUpdate(long? Id)
        {
            if (Id == null || Id == 0)
            {
                // Create
                var dataForm = new CashFlowModel();
                this.HttpContext.BindFormTo(dataForm);
                dataForm.CreateAt = DateTime.Now;
                dataForm.CreateBy = User.Id;

                var result = entityTransaction.DoTransantion<CashFlowService, CashFlowOrdersService>((t, t1, t2) =>
                {
                    var orderId = t1.Insert(dataForm);
                    foreach (CashFlowOrdersModel item in this.ListCashDetailModel)
                    {
                        //item.CreateAt = DateTime.Now;
                    }
                    t2.InsertRange(this.ListCashDetailModel);
                });

                if (result)
                {
                    return Json("Tạo đơn nhập hàng thành công", System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return Json("Tạo đơn hàng không thành công", System.Net.HttpStatusCode.BadRequest);
                }

            }
            return Json("Cập nhật thành công", System.Net.HttpStatusCode.OK);
        }
    }

}
