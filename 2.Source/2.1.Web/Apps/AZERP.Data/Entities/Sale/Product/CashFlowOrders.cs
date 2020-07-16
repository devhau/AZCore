using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CashFlowOrdersService : EntityService<CashFlowOrdersService, CashFlowOrdersModel>, IAZTransient
    {
        public CashFlowOrdersService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }

    /// <summary>
    /// This class use for cash flow detail
    /// </summary>
    [TableInfo(TableName = "az_sale_cashflow_orders")]
    public class CashFlowOrdersModel : IEntity
    {
        [Field(IsKey=true, IsAutoIncrement = true)]
        public long Id {get; set;}
        
        /// <summary>
        /// Field Cash Flow Id constrain with table cash flow
        /// </summary>
        [Field]
        public long CashFlowId { get; set; }

        /// <summary>
        /// Field Order Id constrain with table Order
        /// </summary>
        [Field]
        public long OrderId { get; set; }

        /// <summary>
        /// Field Real Money for cash flow
        /// </summary>
        [Field]
        public decimal RealMoney { get; set; }

        /// <summary>
        /// Create Date
        /// </summary>
        [Field]
        public DateTime CreateDate { get; set; }
    }
}
