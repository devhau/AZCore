using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZERP.Data.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class WorkerTimekeepingService : EntityService< WorkerTimekeepingModel>, IAZTransient
    {
        public WorkerTimekeepingService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
        public void UpdateTimeOver() { 
        }
    }
    /// <summary>
    /// Thông tin của nhóm sản phẩm
    /// </summary>

    [TableInfo(TableName = "az_recruitment_worker_time_keeping")]
    public class WorkerTimekeepingModel : EntityTenantModel< long>
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
        public WorkShift? WorkShift { get; set; }
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

