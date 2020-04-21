using AZERP.Data.Entities;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AZERP.Web.Modules.Product.PurchaseOrders
{
    public class FormUpdatePurchaseOrders : UpdateModule<PurchaseOrderService, PurchaseOrderModel, FormPurchaseOrders>
    {
        PurchaseOrderProductService purchaseOrderProductService;
        SupplierService supplierService;
        ProductService productService;
        public SupplierModel SupplierModel;
        public List<PurchaseOrderProductModel> listProductOrder;
        public List<ProductModel> listProduct;
        
        public FormUpdatePurchaseOrders(
            IHttpContextAccessor httpContext, 
            PurchaseOrderProductService purchaseOrderProductService, 
            SupplierService supplierService,
            ProductService productService) : base(httpContext)
        {
            this.purchaseOrderProductService = purchaseOrderProductService;
            this.supplierService = supplierService;
            this.productService = productService;
        }

        protected override void IntData()
        {
            this.Title = "Thêm đơn nhập hàng";
        }

        public ProductModel getProduct(long Id)
        {
            return this.productService.Select(p => p.Id == Id).FirstOrDefault();
        }

        public override IView Get(long? Id)
        {
            if(Id == 0 || Id == null) return base.Get(Id);
            
            this.Data = this.Service.GetById(Id);
            SupplierModel = this.supplierService.Select(p => p.Id == this.Data.SupplierCode).FirstOrDefault();
            listProductOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == this.Data.Id).ToList();
            this.Title = "Duyệt đơn hàng";
            return View("UpdatePurchaseOrders");
        }

        public override IView Post(long? Id, PurchaseOrderModel DataForm)
        {
            try
            {
                DataForm.CreateAt = DateTime.Now;
                DataForm.CreateBy = User.Id;
                DataFormToData(DataForm);
                var orderId = this.Service.Insert(DataForm);

                foreach (PurchaseOrderProductModel item in this.ManagerForm.listDataOrder)
                {
                    item.PurchaseOrderId = orderId;
                    item.CreateAt = DateTime.Now;
                }

                if (this.purchaseOrderProductService.InsertRange(this.ManagerForm.listDataOrder, true) > 0)
                {
                    this.Service.Commit();
                    return Json("Tạo đơn nhập hàng thành công");
                }

                this.Service.Delete(p => p.Id == orderId);
            } catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return Json("Nhập hàng không thành công",System.Net.HttpStatusCode.InternalServerError);
        }
    }
}
