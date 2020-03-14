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
    [TableInfo(TableName = "bot_proxy")]
    public class ProxyModel : EntityModel<ProxyModel, long>
    {
        [Field]
        public string ip { get; set; }
        [Field]
        public int port { get; set; }
        [Field]
        public bool  IsUse { get; set; }
        [Field]
        public bool IsActice { get; set; }

    }
    public class ProxyService : EntityService<ProxyService, ProxyModel>
    {
        public ProxyService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
