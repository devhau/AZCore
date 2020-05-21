using AZCore.Database;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZERP.Data.Entities;
using AZERP.Data.Enums;
using AZWeb.Extensions;
using AZWeb.Module;
using AZWeb.Module.Attributes;
using AZWeb.Module.Common;
using AZWeb.Module.Page.Manager;
using AZWeb.Module.TagHelper.Module;
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
    [TableColumn(Title = "Nhà cung cấp", FieldName = "PartnerId", DataType = typeof (SupplierService))]
    [TableColumn(Title = "Trạng thái", FieldName = "PurchaseOrderStatus", DataType = typeof(OrderStatus))]
    [TableColumn(Title = "Thanh toán", FieldName = "PurchaseOrderPayment", DataType = typeof(OrderPayment))]
    [TableColumn(Title = "Nhập kho", FieldName = "PurchaseOrderImport", DataType = typeof(PurchaseOrderImport))]
    [TableColumn(Title = "Tổng tiền", FieldName = "TotalNumber", FormatString = "{0:#,###}")]
    [TableColumn(Title = "Nhân viên tạo", FieldName = "CreateBy", DataType = typeof(UserService))]
    [TableColumn(Title = "Ngày tạo", FieldName = "CreateAt")]
    [TableColumn(Title = "Thao tác", LinkFormat = "nhap-hang/commit-nhap-hang.az?Id={Id}", Text = "Duyệt hóa đơn", Display = AZWeb.Module.Enums.DisplayColumn.IconText, Popup = AZWeb.Module.Enums.PopupSize.Extralarge)]
    public class FormPurchaseOrders : ManageModule<PurchaseOrderService, PurchaseOrderModel, FormUpdatePurchaseOrders>
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
        /// Lọc hóa đơn nhập
        /// </summary>
        [QuerySearch]
        public OrderType Type { get; set; } = OrderType.In;
        #endregion

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
        [BindService]
        public IGetGenCodeService genCodeService;

        [BindQuery]
        public long Id { get; set; }
        [BindForm]
        public List<PurchaseOrderProductModel> listDataOrder { get; set; }

        public UserModel UserModel;
        public SupplierModel SupplierModel;
        public PurchaseOrderModel DataCurrent = null;
        public bool CanEdit = true;

        public FormPurchaseOrders(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        protected override IEnumerable<ButtonInfo> CreateButtons() {

            yield return new ButtonInfo() {            
                 ClassName= "btn btn-success btn-sm az-btn az-btn-add",
                 CMD= "f1",
                 PermisisonCode=this.ModuleInfo?.AddCode,
                 Icon= "far fa-plus-square",
                 Text= "Thêm Mới Đơn Hàng (F1)"
            };
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
                T.AddWhere("Type", OrderType.In);
            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                T.AddWhere("Type", OrderType.In);
                actionWhere(T);
            });
            this.PageMax = PageSize>0?(int)Math.Ceiling((decimal)this.PageTotal / (decimal)this.PageSize):0;
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
                SupplierModel = this.supplierService.Select(p => p.Id == DataCurrent.PartnerId).FirstOrDefault();
                UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
                listDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == DataCurrent.Id).ToList();
                if (DataCurrent.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingImport && DataCurrent.PurchaseOrderPayment == OrderPayment.Unpaid && DataCurrent.PurchaseOrderStatus == OrderStatus.Waiting)
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
                if (dataForm.PartnerId == 0)
                    return Json("Chưa chọn nhà cung cấp", System.Net.HttpStatusCode.BadRequest);
                if (dataForm.StoreId == 0)
                    return Json("Chưa chọn kho nhập hàng", System.Net.HttpStatusCode.BadRequest);
                if (this.listDataOrder == null || this.listDataOrder.Count == 0)
                    return Json("Không được để trống danh sách sản phẩm", System.Net.HttpStatusCode.BadRequest);
                
                dataForm.CreateAt = DateTime.Now;
                dataForm.CreateBy = User.Id;
                dataForm.PurchaseOrderStatus = OrderStatus.Waiting;
                dataForm.PurchaseOrderPayment = OrderPayment.Unpaid;
                dataForm.PurchaseOrderImport = AZERP.Data.Enums.PurchaseOrderImport.WaitingImport;
                dataForm.Type = OrderType.In;

                if (dataForm.Code == "" || dataForm.Code == null)
                {
                    dataForm.Code = this.genCodeService.GetGenCode(SystemCode.ImportCode);
                }

                var result = entityTransaction.DoTransantion<PurchaseOrderService, PurchaseOrderProductService>((t, t1, t2) =>
                {
                    var orderId = t1.Insert(dataForm);
                    foreach (PurchaseOrderProductModel item in this.listDataOrder)
                    {
                        item.PurchaseOrderId = orderId;
                        item.CreateAt = DateTime.Now;
                    }
                    t2.InsertRange(this.listDataOrder);
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
            else
            {
                var data = this.Service.GetById(Id);
                var dataForm = new PurchaseOrderModel();
                this.HttpContext.BindFormTo(dataForm);
                // Update - chưa thanh toán - chưa nhập kho
                if ( data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingImport
                    && data.PurchaseOrderPayment == OrderPayment.Unpaid
                    && data.PurchaseOrderStatus == OrderStatus.Waiting)
                {
                    if (dataForm.PartnerId == 0)
                        return Json("Chưa chọn nhà cung cấp", System.Net.HttpStatusCode.BadRequest);
                    if (dataForm.StoreId == 0)
                        return Json("Chưa chọn kho nhập hàng", System.Net.HttpStatusCode.BadRequest);
                    if (this.listDataOrder == null || this.listDataOrder.Count == 0)
                        return Json("Không được để trống danh sách sản phẩm", System.Net.HttpStatusCode.BadRequest);

                    var resultDel = entityTransaction.DoTransantion<PurchaseOrderProductService>((t, t1) =>
                    {
                        t1.Delete(p => p.PurchaseOrderId == data.Id);
                    });

                    if (resultDel)
                    {
                        var result = entityTransaction.DoTransantion<PurchaseOrderService, PurchaseOrderProductService>((t, t1, t2) =>
                        {
                            foreach (var item in this.listDataOrder)
                            {
                                item.PurchaseOrderId = Id.GetValueOrDefault();
                                item.CreateAt = DateTime.Now;
                            }
                            t2.InsertRange(this.listDataOrder);

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
                else // Update - đã thanh toán - chưa nhập kho || chưa thanh toán - đã nhập kho
                {
                    if(data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.WaitingImport)
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

        public IView GetPayment(){
            this.Title = "Thanh toán";
            this.Html.Icon="fas fa-dollar-sign";
            return View("UpdatePayment");
        }

        public IView PostPayment() {
            return Json("Thanh cong");
        }

        [OnlyAjax]
        public IView GetCommit()
        {
            DataCurrent = this.Service.GetById(this.Id);
            SupplierModel = this.supplierService.Select(p => p.Id == DataCurrent.PartnerId).FirstOrDefault();
            UserModel = this.userService.Select(p => p.Id == DataCurrent.CreateBy).FirstOrDefault();
            listDataOrder = this.purchaseOrderProductService.Select(p => p.PurchaseOrderId == this.Id).ToList();
            this.Title = "Duyệt hóa đơn";
            this.Html.Icon = "fas fa-check-double";
            return View("UpdatePurchaseOrders");

        }

        [OnlyAjax]
        public IView PostCommit([BindForm]long commit)
        {
            if(commit != 1 && commit != 2)
            {
                return Json("Thao tác không thành công", System.Net.HttpStatusCode.BadRequest);
            }

            var data = this.Service.GetById(this.Id);
            
            if(commit == 1) // Nhập kho
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderProductService, PurchaseOrderService, StoreProductService>((t, t1, t2, t3) =>
                {
                    var listDetail = t1.Select(p => p.PurchaseOrderId == this.Id).ToList();
                    foreach (var item in listDetail)
                    {
                        var storeProduct = new StoreProductModel();
                        var selectStorePro = t3.Select(p => p.ProductId == item.ProductId && p.StoreId == data.StoreId);
                        
                        // Sản phẩm đã có trong kho
                        // Tồn kho (trong kho) = Tồn kho + lượng nhập
                        // Tồn kho (lịch sử theo từng hóa đơn) = Tồn kho + lượng nhập
                        if (selectStorePro.Count() > 0)
                        {
                            storeProduct = selectStorePro.First();
                            item.Available = storeProduct.Available + item.ImportNumber;
                            storeProduct.Available = storeProduct.Available + item.ImportNumber;
                            t3.Update(storeProduct);
                        }
                        // Sản phẩm chưa có trong kho
                        // Tồn kho (trong kho) = lượng nhập
                        // Tồn kho (lịch sử theo từng hóa đơn) = lượng nhập
                        else
                        {
                            item.Available = item.ImportNumber;
                            storeProduct.ProductId = item.ProductId;
                            storeProduct.StoreId = data.StoreId;
                            storeProduct.Available = item.ImportNumber;
                            storeProduct.CreateAt = DateTime.Now;
                            t3.Insert(storeProduct);
                        }
                        t1.Update(item);
                    }
                    data.PurchaseOrderImport = AZERP.Data.Enums.PurchaseOrderImport.Import;
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
                    return Json("Nhập kho thành công", System.Net.HttpStatusCode.OK);
                } else
                {
                    return Json("Nhập kho thất bại", System.Net.HttpStatusCode.BadRequest);
                }
            } else if (commit == 2) // Xác nhận thanh toán
            {
                var result = entityTransaction.DoTransantion<PurchaseOrderService>((t, t1) =>
                {
                    data.PurchaseOrderPayment = OrderPayment.Paid;
                    data.UpdateAt = DateTime.Now;
                    if (data.PurchaseOrderImport == AZERP.Data.Enums.PurchaseOrderImport.Import)
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
