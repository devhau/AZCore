﻿using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZCore.Extensions;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Extensions;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace AZERP.Web.Modules.Orders.Orders
{
    [TableColumn(Title = "Mã đơn", FieldName = "Code")]
    [TableColumn(Title = "Khách hàng", FieldName = "PartnerId", DataType = typeof (CustomersService))]
    [TableColumn(Title = "Trạng thái", FieldName = "PurchaseOrderStatus", DataType = typeof(OrderStatus))]
    [TableColumn(Title = "Thanh toán", FieldName = "PurchaseOrderPayment", DataType = typeof(OrderPayment))]
    [TableColumn(Title = "Xuất kho", FieldName = "PurchaseOrderImport", DataType = typeof(PurchaseOrderImport))]
    [TableColumn(Title = "Tổng tiền", FieldName = "TotalNumber", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Nhân viên tạo", FieldName = "CreateBy", DataType = typeof(UserService))]
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt")]
    [TableColumn(Title = "Thao tác", LinkFormat = "don-hang/commit-xuat-hang.az?Id={Id}", Text = "Duyệt hóa đơn", Display = AZWeb.Module.Enums.DisplayColumn.IconText, Popup = AZWeb.Module.Enums.PopupSize.Extralarge)]
    public class FormOrders : ManageModule<PurchaseOrderService, PurchaseOrderModel, FormUpdateOrders>
    {
        #region -- Field Search --
        /// <summary>
        /// Lọc trạng thái hóa đơn
        /// </summary>
        [QuerySearch]
        public OrderStatus? PurchaseOrderStatus { get; set; }
        /// <summary>
        /// Lọc trạng thái thanh toán
        /// </summary>
        [QuerySearch]
        public OrderPayment? PurchaseOrderPayment { get; set; }
        /// <summary>
        /// Lọc trạng thái xuất kho
        /// </summary>
        [QuerySearch]
        public PurchaseOrderImport? PurchaseOrderImport { get; set; }
        /// <summary>
        /// Lọc đơn xuất
        /// </summary>
        [QuerySearch]
        public OrderType Type { get; set; } = OrderType.Out;
        #endregion

        [BindService]
        public PurchaseOrderProductService purchaseOrderProductService;
        [BindService]
        public CustomersService CustomersService;
        [BindService]
        public ProductService productService;
        [BindService]
        public UserService userService;
        [BindService]
        public EntityTransaction entityTransaction;
        [BindService]
        public IGenCodeService genCodeService;
        [BindQuery]
        public long Id { get; set; }
        [BindForm]
        public List<PurchaseOrderProductModel> ListDataOrder { get; set; }
        [BindForm]
        public decimal Money { get; set; }

        public UserModel UserModel;
        public CustomersModel CustomersModel;
        public PurchaseOrderModel DataCurrent = null;
        public ProductModel ProductModel;
        public bool CanEdit = true;

        [BindService]
        public StoreService StoreService;
        public List<ProductModel> ListProduct;
        public List<StoreModel> storeModels;
        public List<VariantData> variantDatas;

        public FormOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        public override List<PurchaseOrderModel> GetSearchData()
        {
            var proper = this.GetType().GetPropertyByQuerySearch();
            Action<QuerySQL> actionWhere = (T) =>
            {
                foreach (var p in proper)
                {
                    if (p.Property.GetValue(this) != null)
                        T.AddWhere(p.Property.Name, p.Property.GetValue(this), p.OperatorSQL);
                }
            };
            this.PageTotalAll = Service.ExecuteNoneQuery((T) => {

                T.SetColumn("count(0)");
                T.AddWhere("Type", OrderType.Out);
            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                T.AddWhere("Type", OrderType.Out);
                actionWhere(T);
            });
            //this.PageMax = (int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize);
            this.PageMax = this.PageSize > 0 ? (int)Math.Ceiling(PageTotal / (decimal)PageSize) : 0;
            return Service.ExecuteQuery((T) => {
                if (PageIndex <= 0)
                {
                    PageIndex = 1;
                }
                T.Pagination(PageIndex, PageSize);
                actionWhere(T);
                T.Join("az_purchase_order_product", (t1, t2) => string.Format("{0}.Id={1}.PurchaseOrderId", t1, t2));
                T.SetColumn("az_purchase_order.*,sum(az_purchase_order_product.ImportPrice * az_purchase_order_product.ImportNumber) TotalNumber");
                T.AddGroup("az_purchase_order.id");
            }).ToList();
        }

        protected override void IntData()
        {
            this.Title = "Hóa đơn";
        }

        [OnlyAjax]
        public IView GetPayment(string data)
        {
            decimal money = 0;
            foreach (var item in data.Split(","))
            {
                var orderDetail = this.purchaseOrderProductService.Select(p => p.Id == item.To<long>()).First();
                money += (orderDetail.ImportNumber * orderDetail.ImportPrice);
            }
            this.Money = money;
            this.Title = "Xác nhận thanh toán";
            return View("UpdatePayment");
        }

        [OnlyAjax]
        public IView PostPayment([BindForm] string money)
        {
            var data = this.Service.GetById(this.Id);
            var result = entityTransaction.DoTransantion<PurchaseOrderService, CashFlowService, CashFlowOrdersService>((t, t1, t2, t3) =>
                {
                    var cashFlowIn = new CashFlowModel();
                    cashFlowIn.Code = this.genCodeService.GetGenCode(SystemCode.CashFlowInCode, null, false);
                    cashFlowIn.PartnerId = data.PartnerId;
                    cashFlowIn.Money = money.To<decimal>();
                    cashFlowIn.Type = OrderType.In;
                    cashFlowIn.PartnerType = PartnerType2.Customer;
                    cashFlowIn.CreateAt = DateTime.Now;
                    var cashFlowId = t2.Insert(cashFlowIn);

                    var cashFlowOrder = new CashFlowOrdersModel();
                    cashFlowOrder.CashFlowId = cashFlowId;
                    cashFlowOrder.OrderId = this.Id;
                    cashFlowOrder.RealMoney = money.To<decimal>();
                    cashFlowOrder.CreateDate = DateTime.Now;
                    t3.Insert(cashFlowOrder);

                    data.PurchaseOrderPayment = OrderPayment.Paid;
                    data.UpdateAt = DateTime.Now;
                    if (data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.Export)
                    {
                        data.PurchaseOrderStatus = OrderStatus.Complete;
                        data.CompleteOn = DateTime.Now;
                    }
                    t1.Update(data);
                });
            if (result) {
                return Json("Thực hiện thanh toán thành công", System.Net.HttpStatusCode.OK);
            } else {
                return Json("Không thành công", System.Net.HttpStatusCode.BadRequest);
            }
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
                CustomersModel = this.CustomersService.Select(p => p.Id == DataCurrent.PartnerId).FirstOrDefault();
                UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
                ListDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == DataCurrent.Id).ToList();
                if (DataCurrent.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingExport && DataCurrent.PurchaseOrderPayment == OrderPayment.Unpaid && DataCurrent.PurchaseOrderStatus == OrderStatus.Waiting)
                {
                    CanEdit = true;
                } else
                {
                    CanEdit = false;
                }
                this.Title = "Cập nhật đơn hàng (" + DataCurrent.Code + ")";

            }
            return View("FormUpdateOrders");
        }

        public override IView PostUpdate(long? Id)
        {
            if (Id == null || Id == 0)
            {
                // Create
                var dataForm = new PurchaseOrderModel();
                this.HttpContext.BindFormTo(dataForm);
                if (dataForm.PartnerId == 0)
                    return Json("Chưa chọn khách hàng", System.Net.HttpStatusCode.BadRequest);
                if (this.ListDataOrder == null || this.ListDataOrder.Count == 0)
                    return Json("Không được để trống danh sách sản phẩm", System.Net.HttpStatusCode.BadRequest);
                
                dataForm.CreateAt = DateTime.Now;
                dataForm.CreateBy = User.Id;
                dataForm.PurchaseOrderStatus = OrderStatus.Waiting;
                dataForm.PurchaseOrderPayment = OrderPayment.Unpaid;
                dataForm.PurchaseOrderImport = AZERP.Data.Enums.PurchaseOrderImport.WaitingExport;
                dataForm.Type = OrderType.Out;

                if (dataForm.Code == "" || dataForm.Code == null)
                {
                    dataForm.Code = this.genCodeService.GetGenCode(SystemCode.ExportCode);
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
                    return Json("Tạo đơn hàng thành công", System.Net.HttpStatusCode.OK);
                }
                else
                {
                    return Json("Tạo đơn không thành công", System.Net.HttpStatusCode.InternalServerError);
                }

            } else
            {
                var data = this.Service.GetById(Id);
                var dataForm = new PurchaseOrderModel();
                this.HttpContext.BindFormTo(dataForm);
                // Update - chưa thanh toán - chưa xuất kho
                if ( data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingExport
                    && data.PurchaseOrderPayment == OrderPayment.Unpaid
                    && data.PurchaseOrderStatus == OrderStatus.Waiting)
                {
                    if (dataForm.PartnerId == 0)
                        return Json("Chưa chọn khách hàng", System.Net.HttpStatusCode.BadRequest);
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

                            data.PartnerId = dataForm.PartnerId;
                            data.UpdateBy = User.Id;
                            data.UpdateAt = DateTime.Now;
                            data.Note = dataForm.Note;
                            data.StoreId = dataForm.StoreId;
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
                // Update - đã thanh toán - chưa xuất kho || chưa thanh toán - đã xuất kho
                else
                {
                    if (data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingExport)
                    {
                        data.StoreId = dataForm.StoreId;
                    }
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
        public IView GetCheckStore(string data)
        {
            this.Title = "Kiểm tra tồn kho";
            this.storeModels = StoreService.GetAll().ToList();
            this.variantDatas = StoreService.GetObject(0).ToList();
            this.ListProduct = new List<ProductModel>();
            foreach (var item in data.Split(","))
            {
                var proModel = this.productService.Select(p => p.Id == item.To<long>()).First();
                ListProduct.Add(proModel);
            }
            return View("CheckAvailable");
        }

        public long GetInfo(long storeId, long productId, Func<VariantData, long> func)
        {
            var item = this.variantDatas.FirstOrDefault(p => p.StoreId == storeId && p.ProductId == productId);
            return item == null ? 0 : func(item);
        }

        [OnlyAjax]
        public IView GetCommit()
        {
            DataCurrent = this.Service.GetById(this.Id);
            CustomersModel = this.CustomersService.Select(p => p.Id == DataCurrent.PartnerId).FirstOrDefault();
            UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
            ListDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == this.Id).ToList();
            this.Title = "Duyệt hóa đơn";
            return View("UpdateOrders");

        }
        
        /// <summary>
        /// Duyệt hóa đơn
        /// </summary>
        /// <param name="commit"></param>
        /// <returns></returns>
        [OnlyAjax]
        public IView PostCommit([BindForm]long commit)
        {
            if(commit != 1 && commit != 2)
            {
                return Json("Thao tác không thành công", System.Net.HttpStatusCode.BadRequest);
            }

            var data = this.Service.GetById(this.Id);
            
            if(commit == 1) // Xuất kho
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderProductService, PurchaseOrderService, StoreProductService>((t, t1, t2, t3) =>
                {
                    var listDetail = t1.Select(p => p.PurchaseOrderId == this.Id).ToList();
                    foreach (var item in listDetail)
                    {
                        // Sản phẩm đã có trong kho
                        // Tồn kho (trong kho) = Tồn kho - lượng xuất
                        // Tồn kho (theo từng hóa đơn) = Tồn kho - lượng xuất
                        var storeProduct = t3.Select(p => p.ProductId == item.ProductId && p.StoreId == data.StoreId).First();
                        item.Available = storeProduct.Available - item.ImportNumber;
                        storeProduct.Available = storeProduct.Available - item.ImportNumber;
                        t1.Update(item);
                        t3.Update(storeProduct);
                    }
                    data.PurchaseOrderImport = AZERP.Data.Enums.PurchaseOrderImport.Export;
                    data.UpdateAt = DateTime.Now;

                    if (data.PurchaseOrderPayment == OrderPayment.Paid)
                    {
                        data.PurchaseOrderStatus = OrderStatus.Complete;
                        data.CompleteOn = DateTime.Now;
                    }

                    t2.Update(data);
                });
                if(result)
                {
                    return Json("Xuất kho thành công", System.Net.HttpStatusCode.OK);
                } else
                {
                    return Json("Xuất kho thất bại", System.Net.HttpStatusCode.BadRequest);
                }
            } else if (commit == 2) // Xác nhận thanh toán
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderService>((t, t1) =>
                {
                    data.PurchaseOrderPayment = OrderPayment.Paid;
                    data.UpdateAt = DateTime.Now;
                    if (data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.Export)
                    {
                        data.PurchaseOrderStatus = OrderStatus.Complete;
                        data.CompleteOn = DateTime.Now;
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
