using AZCore.Database;
using AZCore.Domain;
using AZCore.Identity;
using AZCore.Utility;
using System.Data;
using System.Linq;

namespace AZ.Web.Entities
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
      
        
    }
    /// <summary>
    /// Thông tin tài khoản
    /// Thằng nào tìm được thông tin của tao thì tao cũng cặn lời
    /// </summary>
    public class UserModel : AZUser<UserModel, long>
    {
              
    }
}
