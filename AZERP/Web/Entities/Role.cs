﻿using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Entities
{
    public class RoleService : EntityService<RoleService, RoleModel>, IAZTransient
    {
        public RoleService(IDbConnection _connection) : base(_connection)
        {
        }
    }
    public class RoleModel : AZRole<RoleModel, long>
    {
    }
}