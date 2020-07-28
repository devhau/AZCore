using AZCore.Database;
using AZCore.Database.Attributes;
using AZCore.Domain;
using AZCore.Identity;
using AZWeb.Module.Attributes;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// Serivce của Tài khoản
    /// </summary>
    public class UserService : EntityService<UserService, UserModel>, IAZTransient, IIdentityService
    {
        public UserService(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }
        /// <summary>
        /// Tìm thông tin bởi Email hoặc Tài khoản
        /// Tao không thích cho mày tìm số điện thoại đó làm gì được nhau.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserModel GetEmailOrUsername(string name) {
            return this.Select(p => p.Email == name || p.UserName == name).FirstOrDefault();
        }
        public IEnumerable<string> GetPermissionByUserId(long UserId)
        {
            var que = new AZCore.Database.SQL.SQLResult();
            que.SQL = @"
            SELECT DISTINCT T6.Code
                FROM
                  ((
                        SELECT T2.PermissionCode as Code
                       FROM az_common_user_permission T2
                       WHERE T2.UserId=@UserId
                    )
                   UNION 
                    (SELECT T4.PermissionCode as Code
                       FROM  az_common_role_permission T4
                       JOIN az_common_user_role T5 ON T4.RoleId = T5.RoleId
                        WHERE T5.UserId=@UserId
                )
                ) T6
                    
        ";
            que.Param = new Dapper.DynamicParameters();
            que.Param.Add("@UserId", UserId);
            return ExecuteQuery<PermissionModel>(que).Select(p=>p.Code);
        }

        public long GetTenantByUserId(long UserId)
        {
            throw new System.NotImplementedException();
        }
    }
    /// <summary>
    /// Thông tin tài khoản
    /// Thằng nào tìm được thông tin của tao thì tao cũng cặn lời
    /// </summary>
    public class UserModel : AZUser<UserModel>
    {

        [Field(Length = 1000)]
        [FieldUploadFile(IsGenAutoNamFile =true)]
        public override string Avatar { get; set; }
    }
}
