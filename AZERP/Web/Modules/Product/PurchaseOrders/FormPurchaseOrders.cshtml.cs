﻿using AZCore.Database;
using AZCore.Database.Enums;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Extensions;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace AZERP.Web.Modules.Product.PurchaseOrders
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    [TableColumn(Title = "Nhà cung cấp", FieldName = "SupplierCode", DataType = typeof (SupplierService))]
    [TableColumn(Title = "Trạng thái", FieldName = "PurchaseOrderStatus", DataType = typeof(OrderStatus))]
    [TableColumn(Title = "Thanh toán", FieldName = "PurchaseOrderPayment", DataType = typeof(OrderPayment))]
    [TableColumn(Title = "Nhập kho", FieldName = "PurchaseOrderImport", DataType = typeof(PurchaseOrderImport))]
    [TableColumn(Title = "Tổng tiền")]
    [TableColumn(Title = "Nhân viên tạo", FieldName = "CreateBy")]
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt")]
    [TableColumn(Title = "Thao tác", LinkFormat = "nhap-hang/commit-nhap-hang.az?Id={Id}", Text = "Duyệt hóa đơn", Display = AZWeb.Module.Enums.DisplayColumn.IconText, Icon = "fas fa-key", Popup = AZWeb.Module.Enums.PopupSize.Extralarge)]
    public class FormPurchaseOrders : ManageModule<PurchaseOrderService, PurchaseOrderModel, FormUpdatePurchaseOrders>
    {
        [BindService]
        public PurchaseOrderProductService purchaseOrderProductService;
        [BindService]
        public SupplierService supplierService;
        [BindService]
        public ProductService productService;
        [BindService]
        public UserService userService;
        [BindService]
        public EntityTransaction entityTransaction;

        [BindQuery]
        public long Id { get; set; }
        [BindForm]
        public List<PurchaseOrderProductModel> ListDataOrder { get; set; }

        public UserModel UserModel;
        public SupplierModel SupplierModel;
        public PurchaseOrderModel DataCurrent = null;
        public bool CanEdit = true;

        public FormPurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }
        protected override void IntData()
        {
            this.Title = "Nhập hàng";
        }

        public override IView GetUpdate(long? Id)
        {
            if (Id == null || Id == 0)
            {
                // View Create Purchase Order
                this.Title = "Thêm mới hóa đơn";
            } else
            {
                // View Update Purchase Order
                DataCurrent = this.Service.GetById(Id);
                SupplierModel = this.supplierService.Select(p => p.Id == DataCurrent.SupplierCode).FirstOrDefault();
                UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
                ListDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == DataCurrent.Id).ToList();
                if (DataCurrent.PurchaseOrderImport == PurchaseOrderImport.Waiting && DataCurrent.PurchaseOrderPayment == OrderPayment.Unpaid && DataCurrent.PurchaseOrderStatus == OrderStatus.Waiting)
                {
                    CanEdit = true;
                } else
                {
                    CanEdit = false;
                }
                this.Title = "Cập nhật đơn hàng (" + DataCurrent.Code + ")";

            }
            return View("FormUpdatePurchaseOrders");
        }

        public override IView PostUpdate(long? Id)
        {
            if (Id == null || Id == 0)
            {
                // Create
                var dataForm = new PurchaseOrderModel();
                this.HttpContext.BindFormTo(dataForm);
                if (dataForm.SupplierCode == 0)
                    return Json("Chưa chọn nhà cung cấp", System.Net.HttpStatusCode.BadRequest);
                if (this.ListDataOrder == null || this.ListDataOrder.Count == 0)
                    return Json("Không được để trống danh sách sản phẩm", System.Net.HttpStatusCode.BadRequest);
                
                dataForm.CreateAt = DateTime.Now;
                dataForm.CreateBy = User.Id;
                dataForm.PurchaseOrderStatus = OrderStatus.Waiting;
                dataForm.PurchaseOrderPayment = OrderPayment.Unpaid;
                dataForm.PurchaseOrderImport = PurchaseOrderImport.Waiting;

                if (dataForm.Code == "" || dataForm.Code == null)
                {
                    dataForm.Code = "PON" + String.Format("{0:D5}", this.Service.GetAll().Count() + 1);
                }

                var result = entityTransaction.DoTransantion<PurchaseOrderService, PurchaseOrderProductService>((t, t1, t2) =>
                {
                    var orderId = t1.Insert(dataForm);
                    foreach (PurchaseOrderProductModel item in this.ListDataOrder)
                    {
                        item.PurchaseOrderId = orderId;
                        item.CreateAt = DateTime.Now;
                    }
                    t2.InsertRange(this.ListDataOrder);
                });

                if (result)
                {
                    return Json("Tạo đơn nhập hàng thành công", System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return Json("Nhập hàng không thành công", System.Net.HttpStatusCode.InternalServerError);
                }

            } else
            {
                var data = this.Service.GetById(Id);
                var dataForm = new PurchaseOrderModel();
                this.HttpContext.BindFormTo(dataForm);
                // Update - chưa thanh toán - chưa nhập kho
                if ( data.PurchaseOrderImport == PurchaseOrderImport.Waiting 
                    && data.PurchaseOrderPayment == OrderPayment.Unpaid
                    && data.PurchaseOrderStatus == OrderStatus.Waiting)
                {
                    if (dataForm.SupplierCode == 0)
                        return Json("Chưa chọn nhà cung cấp", System.Net.HttpStatusCode.BadRequest);
                    if (this.ListDataOrder == null || this.ListDataOrder.Count == 0)
                        return Json("Không được để trống danh sách sản phẩm", System.Net.HttpStatusCode.BadRequest);

                    var resultDel = entityTransaction.DoTransantion<PurchaseOrderProductService>((t, t1) =>
                    {
                        t1.Delete(p => p.PurchaseOrderId == data.Id);
                    });

                    if (resultDel)
                    {
                        var result = entityTransaction.DoTransantion<PurchaseOrderService, PurchaseOrderProductService>((t, t1, t2) =>
                        {
                            foreach (var item in this.ListDataOrder)
                            {
                                item.PurchaseOrderId = Id.GetValueOrDefault();
                                item.CreateAt = DateTime.Now;
                            }
                            t2.InsertRange(this.ListDataOrder);

                            data.SupplierCode = dataForm.SupplierCode;
                            data.UpdateBy = User.Id;
                            data.UpdateAt = DateTime.Now;
                            data.Note = dataForm.Note;
                            t1.Update(data);
                        });
                        if (result)
                        {
                            return Json("Cập nhật thành công", System.Net.HttpStatusCode.OK);
                        }
                        else
                        {
                            return Json("Cập nhật không thành công", System.Net.HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        return Json("Cập nhật không thành công", System.Net.HttpStatusCode.InternalServerError);
                    }
                }
                else // Update - đã thanh toán - chưa nhập kho || chưa thanh toán - đã nhập kho
                {
                    data.Note = dataForm.Note;
                    var result = entityTransaction.DoTransantion<PurchaseOrderService>((t, t1) =>
                    {
                        t1.Update(data);
                    });
                    if (result)
                    {
                        return Json("Cập nhật thành công", System.Net.HttpStatusCode.OK);
                    }
                    else
                    {
                        return Json("Cập nhật không thành công", System.Net.HttpStatusCode.InternalServerError);
                    }
                }
            }
        }

        [OnlyAjax]
        public IView GetCommit()
        {
            DataCurrent = this.Service.GetById(this.Id);
            SupplierModel = this.supplierService.Select(p => p.Id == DataCurrent.SupplierCode).FirstOrDefault();
            UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
            ListDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == this.Id).ToList();
            this.Title = "Duyệt hóa đơn";
            return View("UpdatePurchaseOrders");

        }
        [OnlyAjax]
        public IView PostCommit(long commit)
        {
            if(commit != 1 && commit != 2)
            {
                return Json("Thao tác không thành công", System.Net.HttpStatusCode.BadRequest);
            }

            var data = this.Service.GetById(this.Id);
            
            if(commit == 1)
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderProductService, ProductService, PurchaseOrderService>((t, t1, t2, t3) =>
                {
                    var listDetail = t1.Select(p => p.PurchaseOrderId == this.Id).ToList();
                    foreach (var item in listDetail)
                    {
                        var product = t2.Select(p => p.Id == item.ProductId).First();
                        product.Available += item.ImportNumber;
                        t2.Update(product);
                    }
                    data.PurchaseOrderImport = PurchaseOrderImport.Import;

                    if (data.PurchaseOrderPayment == OrderPayment.Paid)
                    {
                        data.PurchaseOrderStatus = OrderStatus.Complete;
                    }

                    t3.Update(data);
                });
                if(result)
                {
                    return Json("Nhập kho thành công", System.Net.HttpStatusCode.OK);
                } else
                {
                    return Json("Nhập kho thất bại", System.Net.HttpStatusCode.BadRequest);
                }
            } else if (commit == 2)
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderService>((t, t1) =>
                {
                    data.PurchaseOrderPayment = OrderPayment.Paid;
                    if (data.PurchaseOrderImport == PurchaseOrderImport.Import)
                    {
                        data.PurchaseOrderStatus = OrderStatus.Complete;
                    }
                    t1.Update(data);
                });
                if (result)
                {
                    return Json("Thanh toán thành công", System.Net.HttpStatusCode.OK);
                } else
                {
                    return Json("Thanh toán thất bại", System.Net.HttpStatusCode.BadRequest);
                }
            }
            return Json("Thao tác không thành công", System.Net.HttpStatusCode.BadRequest);
        }

        public ProductModel getProduct(long Id)
        {
            return this.productService.Select(p => p.Id == Id).FirstOrDefault();
        }
    }
}
