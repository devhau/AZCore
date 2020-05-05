using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Database.SQL;
using AZCore.Domain;
using AZERP.Data.Enums;
using AZWeb.Module.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class StoreService : EntityService<StoreService, StoreModel>, IAZTransient
    {
        public StoreService(IDbConnection _connection) : base(_connection)
        {
        }
        public IEnumerable<VariantData> GetObject(long storeId)
        {
            var sql = new SQLResult();
            sql.Param = new Dapper.DynamicParameters();
            sql.Param.Add("@storeId", storeId);
            string strWhere = "";
            if(storeId > 0)
            {
                strWhere = " WHERE `az_purchase_order`.StoreId = @storeId ";
            }

            sql.SQL = string.Format(@"
                SELECT `az_purchase_order`.StoreId ,`az_purchase_order_product`.ProductId, `az_store_product`.Available , 
                SUM(CASE WHEN az_purchase_order.Type = 1 AND az_purchase_order.PurchaseOrderImport = 1 AND az_purchase_order.PurchaseOrderStatus = 1 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Incoming,
                SUM(CASE WHEN az_purchase_order.Type = 2 AND az_purchase_order.PurchaseOrderImport = 4 AND az_purchase_order.PurchaseOrderStatus = 1 THEN az_purchase_order_product.ImportNumber ELSE 0 END) OnWay,
                SUM(CASE WHEN az_purchase_order.Type = 2 AND az_purchase_order.PurchaseOrderImport = 3 AND az_purchase_order.PurchaseOrderStatus = 1 THEN az_purchase_order_product.ImportNumber ELSE 0 END) Committed
                FROM `az_purchase_order`
	                LEFT JOIN `az_purchase_order_product` on `az_purchase_order`.Id = `az_purchase_order_product`.PurchaseOrderId
                    LEFT JOIN `az_store_product`  on `az_purchase_order`.StoreId = `az_store_product`.StoreId AND `az_purchase_order_product`.ProductId = `az_store_product`.ProductId
                {0} GROUP BY `az_purchase_order`.StoreId ,`az_purchase_order_product`.ProductId
                ", strWhere);
            return this.ExecuteQuery<VariantData>(sql);
        }
    }

    public class VariantData
    {
        public long StoreId { get; set; }
        public long ProductId { get; set; }
        public long Available { get; set; }
        public long Incoming { get; set; }
        public long OnWay { get; set; }
        public long Committed { get; set; }
    }
    /// <summary>
    /// Thông tin kho
    /// </summary>

    [TableInfo(TableName = "az_store")]
    public class StoreModel : EntityModel<StoreModel, long>
    {
        /// <summary>
        /// Mã kho
        /// </summary>
        [FieldAutoGenCode(Key = SystemCode.StoreCode)]
        [Field(Length = 50)]
        public string Code { get; set; }
        /// <summary>
        /// Tên Kho
        /// </summary>
        [Field(Length = 500)]
        [FieldDisplay]
        public string Name { get; set; }
        /// <summary>
        /// Tên viết tắt
        /// </summary>
        [Field(Length = 500)]
        public string AbbreviatedName { get; set; }
        /// <summary>
        /// Số điện thoại kho
        /// </summary>
        [Field(Length = 50)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        [Field(Length = 500)]
        public string Address { get; set; }
        /// <summary>
        /// Mô tả kho
        /// </summary>
        [Field(Length = 500)]
        public string Description { get; set; }
    }
}
