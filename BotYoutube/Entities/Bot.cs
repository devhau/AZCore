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
    [TableInfo(TableName = "bot_bot")]
    public class BotModel : EntityModel<BotModel, long>
    {
        [Field]
        public string ip { get; set; }
        [Field]
        public DateTime LastLogin { get; set; }
        [Field]
        public DateTime LastProcess { get; set; }
        [Field]
        public bool IsActice { get; set; }

    }
    public class BotService : EntityService<BotService, BotModel>
    {
        public BotService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
