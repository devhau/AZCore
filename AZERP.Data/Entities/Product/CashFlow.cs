using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CashFlowService : EntityService<CashFlowService, CashFlowModel>, IAZTransient
    {
        public CashFlowService(IDbConnection _connection) : base(_connection)
        {
        }
    }

    /// <summary>
    /// This class use for cash flow order
    /// </summary>
    [TableInfo(TableName = "az_cashflow")]
    public class CashFlowModel : EntityModel<CashFlowModel, long>
    {
        /// <summary>
        /// Field Cash Flow Code
        /// </summary>
        [Field]
        public string Code { get; set; }

        /// <summary>
        /// Field Order id Constrain table with table az order
        /// </summary>
        [Field]
        public long OrderId { get; set; }

        /// <summary>
        /// Field partner id constrain with tables az customer or az supplier
        /// </summary>
        [Field]
        public long PartnerId { get; set; }

        /// <summary>
        /// Field money of cash flow
        /// </summary>
        [Field]
        public double Money { get; set; }

        /// <summary>
        /// Field type of cash flow
        /// </summary>
        [Field]
        public OrderType Type { get; set; }

        /// <summary>
        /// Field completed date of cash flow
        /// </summary>
        [Field]
        public DateTime CompletedDate { get; set; }

        /// <summary>
        /// Field payment date of cash flow
        /// </summary>
        [Field]
        public DateTime PaymentDate { get; set; }
    }
}
