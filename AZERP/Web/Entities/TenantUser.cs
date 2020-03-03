using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Entities
{
    public class TenantUserService : EntityService<TenantUserService, TenantUserModel>, IAZTransient
    {
        public TenantUserService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class TenantUserModel : AZTenantUser<TenantUserModel, long>
    {
    }
    
}
