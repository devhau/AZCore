using AZCore.Database;
using AZCore.Database.Attr;
using AZCore.Domain;
using AZCore.Identity;
using AZCore.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZ.Web.Entities
{
    public class UserService : EntityService<UserService, UserModel>, IAZTransient
    {
        public UserService(IDbConnection _connection) : base(_connection)
        {
        }
        public UserModel GetEmailOrUsername(string name) {
            var rs = buildSQL.SQLSelect();
            rs.SQL = string.Format("{0} where Email=@name or UserName=@name", rs.SQL);
            rs.Param = new Dapper.DynamicParameters();
            rs.Param.Add("@name",name);
            return ExecuteQuery(rs).FirstOrDefault();
        }
        public bool HasPassword(UserModel user,string passowrd) {
            return user.Password == HashPassword.Create(passowrd, user.Salt);
        }
        
    }
    public class UserModel : AZUser<UserModel, long>
    {
        [Field(IsKey = true,IsAutoIncrement =true)]
        public override long Id { get; set; }
       
    }
}
