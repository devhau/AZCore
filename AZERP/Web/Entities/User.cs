using AZCore.Database.Attr;
using AZCore.Domain;
using AZCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Entities
{
    public class User : AZUser<User, long>, IAZTransient
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        public override long Id { get; set; }
        public User(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
