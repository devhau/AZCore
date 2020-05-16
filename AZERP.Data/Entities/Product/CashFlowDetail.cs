using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Data;

namespace AZERP.Data.Entities
{
    public class CashFlowDetailService : EntityService<CashFlowDetailService, CashFlowDetailModel>, IAZTransient
    {
        public CashFlowDetailService(IDbConnection _connection) : base(_connection)
        {
        }
    }

    /// <summary>
    /// This class use for cash flow detail
    /// </summary>
    [TableInfo(TableName = "az_cashflowdetail")]
    public class CashFlowDetailModel : EntityModel<CashFlowDetailModel, long>
    {
        /// <summary>
        /// Field Cash Flow Id constrain with table cash flow
        /// </summary>
        [Field]
        public long CashFlowId { get; set; }

        /// <summary>
        /// Field Real Money for cash flow
        /// </summary>
        [Field]
        public double RealMoney { get; set; }
    }
}
