using BotYoutube.Database;
using BotYoutube.Database.Attr;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Entities
{
    [TableInfo(TableName = "bot_user")]
    public class UserModel : EntityModel<UserModel, long>
    {
        public UserModel() { }
        [Field]
        public string username { get; set; }
        [Field]
        public string passsword { get; set; }

        [Field]
        public bool IsAdmin { get; set; }
    }
    public class UserService : EntityService<UserService, UserModel>
    {
        public UserService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
