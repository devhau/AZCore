using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class WorkerCheckinCheckoutService : EntityService<WorkerCheckinCheckoutService, WorkerCheckinCheckoutModel>, IAZTransient
    {
        public WorkerCheckinCheckoutService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>

    [TableInfo(TableName = "az_worker_checkin_checkout")]
    public class WorkerCheckinCheckoutModel : EntityModel<WorkerCheckinCheckoutModel, long>
    {
        public long WorkerId { get; set; }
        public DateTime WorkDay { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}

