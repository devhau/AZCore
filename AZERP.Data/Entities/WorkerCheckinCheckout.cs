using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using AZERP.Data.Enums;
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
        /// <summary>
        /// Công nhân
        /// </summary>
        [Field]
        public long WorkerId { get; set; }
        /// <summary>
        /// Công ty
        /// </summary>
        [Field]
        public long CompanyId { get; set; }
        /// <summary>
        /// Ngày làm việc
        /// </summary>
        [Field]
        public DateTime WorkDay { get; set; }
        /// <summary>
        /// Giờ vào công ty
        /// </summary>
        [Field]
        public DateTime? CheckIn { get; set; }
        /// <summary>
        /// Giờ rời khỏi công ty
        /// </summary>
        [Field]
        public DateTime? CheckOut { get; set; }
        /// <summary>
        /// Ca làm việc
        /// </summary>
        [Field]
        public EnumWorkShift? WorkShift { get; set; }
        /// <summary>
        /// Thời gian làm việc
        /// </summary>
        [Field]
        public float TimeWork {get;set; }
        /// <summary>
        /// Thời gian làm thêm
        /// </summary>
        [Field]
        public float OverTimeWork { get; set; }
    }
}

