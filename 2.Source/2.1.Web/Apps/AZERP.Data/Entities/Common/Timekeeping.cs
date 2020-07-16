using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZERP.Data.Entities
{
    public class TimekeepingService : EntityService<TimekeepingService, TimekeepingModel>, IAZTransient
    {
        public TimekeepingService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
    }
    [TableInfo(TableName = "az_common_time_keeping")]
    public class TimekeepingModel : EntityTenantModel<TimekeepingModel,long>
    {

    }
}
