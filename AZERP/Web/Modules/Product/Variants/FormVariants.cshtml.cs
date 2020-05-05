using Aspose.Cells;
using AZCore.Database.Enums;
using AZCore.Database.SQL;
using AZCore.Excel;
using AZERP.Data.Entities;
using AZWeb.Module.Attributes;
using AZWeb.Module.Page.Manager;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AZERP.Web.Modules.Product.Variants
{
    
    //[TableColumn(Title = "Mã SKU", FieldName = "Code")]
    //[TableColumn(Title = "Sản phẩm", FieldName = "Name")]
    //[TableColumn(Title = "Nhóm", FieldName = "CategoryId", DataType = typeof(CategoryService))]
    //[TableColumn(Title = "Tồn kho", FieldName = "Available")]
    //[TableColumn(Title = "Hàng đang về", FieldName = "Incoming")]
    //[TableColumn(Title = "Hàng đang giao", FieldName = "OnWay")]
    //[TableColumn(Title = "Đang giao dịch", FieldName = "Committed")]
    //[TableColumn(Title = "Trạng Thái", FieldName = "ProductSellable", TextFalse = "Đang không hoạt động", TextTrue = "Đang hoạt động")]
    public class FormVariants : ManageModule<ProductService, ProductModel, FormUpdateVariants>
    {
        #region -- Field Search --
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Code { get; set; }
        /// <summary>
        /// Tên Sản Phẩm
        /// </summary>
        [QuerySearch(OperatorSQL = OperatorSQL.LIKE)]
        public string Name { get; set; }
        /// <summary>
        /// Mã kho
        /// </summary>
        [BindQuery]
        public long StoreId { get; set; } = 0;
        #endregion

        [BindService]
        public StoreService StoreService;

        public List<StoreModel> storeModels;
        public List<VariantData> variantDatas;

        public long GetInfo(long storeId, long productId, Func<VariantData, long> func)
        {
            var item = variantDatas.FirstOrDefault(p => p.StoreId == storeId && p.ProductId == productId);
            return item == null ? 0 : func(item);
        }

        public override List<ProductModel> GetSearchData()
        {
            if (this.StoreId == 0)
            {
                this.storeModels = StoreService.GetAll().ToList();
            }
            else
            {
                this.storeModels = StoreService.Select(p => p.Id == this.StoreId).ToList();
            }

            this.variantDatas = StoreService.GetObject(this.StoreId).ToList();

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

            });
            this.PageTotal = Service.ExecuteNoneQuery((T) => {
                T.SetColumn("count(0)");
                actionWhere(T);
            });
            this.PageMax = PageSize>0?(int)Math.Ceiling((decimal)this.PageTotal / (decimal)PageSize):0;
            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
            return Service.ExecuteQuery((T) => {
                T.Pagination(PageIndex, PageSize);
                //T.Join("az_purchase_order_product", (t1, t2) =>$"{t1}.Id={t2}.ProductId", JoinType.LeftOuterJoin);
                //T.Join("az_purchase_order_product", "az_purchase_order", (t1, t2) => $"{ t1}.PurchaseOrderId={t2}.Id", JoinType.LeftOuterJoin);
                //T.SetColumn(@" az_product.* , 
                //  SUM(CASE  WHEN az_purchase_order.Type = 0 AND az_purchase_order.PurchaseOrderImport = 0 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Incoming,
                //  SUM(CASE  WHEN az_purchase_order.Type = 1 AND az_purchase_order.PurchaseOrderImport = 3 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) OnWay,
                //  SUM(CASE  WHEN az_purchase_order.Type = 1 AND az_purchase_order.PurchaseOrderImport = 2 AND az_purchase_order.PurchaseOrderStatus = 0 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Committed
                //    ");
                //T.AddGroup("az_product.Id");
                actionWhere(T);
            }).ToList();
        }
        public FormVariants(IHttpContextAccessor httpContext) : base(httpContext)
        {
        }

        protected override void IntData()
        {
            this.Title = "Quản lý tồn kho";
        }

        protected override void FillExcel(ExcelGrid excelGrid, object Data, List<IExcelColumn> columns)
        {
            Workbook wb = new Workbook();
            Worksheet sheet = wb.Worksheets[0];
            sheet.Cells.Merge(1, 1, 2, 2);

            columns = new List<IExcelColumn>();
            var dataTable = new DataTable();
            dataTable.Columns.Add("Index", typeof(long));
            dataTable.Columns.Add("Code", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            columns.Add(new TableColumnAttribute() { FieldName = "Index", Title = "#", Width = 40, TotalMergeRows =2 });
            columns.Add(new TableColumnAttribute() { FieldName = "Code", Title = "SKU", Width = 120,  TotalMergeRows = 2 });
            columns.Add(new TableColumnAttribute() { FieldName = "Name", Title = "Sản phẩm", Width = 400, TotalMergeRows = 2, Height = 40 });
            var rowTitle = dataTable.NewRow();
            foreach (var item in this.storeModels)
            {
                dataTable.Columns.Add(item.Code + "Available", typeof(string));
                dataTable.Columns.Add(item.Code + "Incoming", typeof(string));
                dataTable.Columns.Add(item.Code + "Onway", typeof(string));
                dataTable.Columns.Add(item.Code + "Commited", typeof(string));
                columns.Add(new TableColumnAttribute() { FieldName = item.Code + "Available", Title = item.Name, Width = 70, TotalMergeColumns = 4 });
                columns.Add(new TableColumnAttribute() { FieldName = item.Code + "Incoming", Width = 80 });
                columns.Add(new TableColumnAttribute() { FieldName = item.Code + "Onway", Width = 90 });
                columns.Add(new TableColumnAttribute() { FieldName = item.Code + "Commited", Width = 120 });
                rowTitle[item.Code + "Available"] = "Tồn kho";
                rowTitle[item.Code + "Incoming"] = "Đang về";
                rowTitle[item.Code + "Onway"] = "Đang giao";
                rowTitle[item.Code + "Commited"] = "Đang giao dịch";
            }
            dataTable.Columns.Add("sumAvailable", typeof(string));
            dataTable.Columns.Add("sumIncoming", typeof(string));
            dataTable.Columns.Add("sumOnway", typeof(string));
            dataTable.Columns.Add("sumCommited", typeof(string));
            columns.Add(new TableColumnAttribute() { FieldName = "sumAvailable", Title = "Tổng", Width = 70, TotalMergeColumns = 4 });
            columns.Add(new TableColumnAttribute() { FieldName = "sumIncoming", Width = 80 });
            columns.Add(new TableColumnAttribute() { FieldName = "sumOnway", Width = 90 });
            columns.Add(new TableColumnAttribute() { FieldName = "sumCommited", Width = 120 });
            rowTitle["sumAvailable"] = "Tồn kho";
            rowTitle["sumIncoming"] = "Đang về";
            rowTitle["sumOnway"] = "Đang giao";
            rowTitle["sumCommited"] = "Đang giao dịch";

            dataTable.Rows.Add(rowTitle);

            var index = 1;
            long sumAvai = 0;
            long sumIn = 0;
            long sumOnway = 0;
            long sumCommit = 0;
            foreach (var item in this.Data)
            {
                var dr = dataTable.NewRow();
                dr["Index"] = index;
                dr["Code"] = item.Code;
                dr["Name"] = item.Name;

                foreach(var item1 in this.storeModels)
                {
                    long available = this.GetInfo(item1.Id, item.Id, (item) => item.Available);
                    long incoming = this.GetInfo(item1.Id, item.Id, (item) => item.Incoming);
                    long onway = this.GetInfo(item1.Id, item.Id, (item) => item.OnWay);
                    long commited = this.GetInfo(item1.Id, item.Id, (item) => item.Committed);
                    dr[item1.Code + "Available"] = available == 0 ? "-" : string.Format("{0:#,####}", available);
                    dr[item1.Code + "Incoming"] = incoming == 0 ? "-" : string.Format("{0:#,####}", incoming);
                    dr[item1.Code + "Onway"] = onway == 0 ? "-" : string.Format("{0:#,####}", onway);
                    dr[item1.Code + "Commited"] = commited == 0 ? "-" : string.Format("{0:#,####}", commited);
                    sumAvai += @available;
                    sumIn += incoming;
                    sumOnway += onway;
                    sumCommit += commited;
                }
                dr["sumAvailable"] = sumAvai == 0 ? "-" : string.Format("{0:#,####}", sumAvai);
                dr["sumIncoming"] = sumIn == 0 ? "-" : string.Format("{0:#,####}", sumIn);
                dr["sumOnway"] = sumOnway == 0 ? "-" : string.Format("{0:#,####}", sumOnway);
                dr["sumCommited"] = sumCommit == 0 ? "-" : string.Format("{0:#,####}", sumCommit);
                index++;
                dataTable.Rows.Add(dr);
            }
            base.FillExcel(excelGrid, dataTable, columns);
        }
    }
}
