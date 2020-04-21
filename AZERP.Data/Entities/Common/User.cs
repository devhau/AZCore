using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AZERP.Data.Entities
{
    /// <summary>
    /// Serivce của Tài khoản
    /// </summary>
    public class UserService : EntityService<UserService, UserModel>, IAZTransient
    {
        public UserService(IDbConnection _connection) : base(_connection)
        {
        }
        /// <summary>
        /// Tìm thông tin bởi Email hoặc Tài khoản
        /// Tao không thích cho mày tìm số điện thoại đó làm gì được nhau.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public UserModel GetEmailOrUsername(string name) {
            var rs = buildSQL.SQLSelect();
            rs.SQL = string.Format("{0} where Email=@name or UserName=@name", rs.SQL);
            rs.Param = new Dapper.DynamicParameters();
            rs.Param.Add("@name",name);
            return ExecuteQuery(rs).FirstOrDefault();
        }
        public IEnumerable<PermissionModel> GetPermissionByUserId(long UserId) {

            var que = new AZCore.Database.SQL.SQLResult()
            {

            };
            que.SQL = @"
            SELECT DISTINCT *
                FROM
                  ((SELECT T1.Code

                   FROM az_permission T1

                   JOIN az_user_permission T2 ON T1.Id = T2.PermissionId
                   WHERE T2.UserId=@UserId
                    )
                   UNION 
                    (SELECT T3.Code
                   FROM az_permission T3

                   JOIN az_role_permission T4 ON T3.Id = T4.PermissionId

                   JOIN az_user_role T5 ON T4.RoleId = T5.RoleId
                    WHERE T5.UserId=@UserId)
                    ) T6
                    
        ";
            que.Param = new Dapper.DynamicParameters();
            que.Param.Add("@UserId",UserId);
            return ExecuteQuery<PermissionModel>(que);
        }
      
        
    }
    /// <summary>
    /// Thông tin tài khoản
    /// Thằng nào tìm được thông tin của tao thì tao cũng cặn lời
    /// </summary>
    public class UserModel : AZUser<UserModel>
    {
              
    }
}
