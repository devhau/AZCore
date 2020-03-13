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
    [TableInfo(TableName = "bot_accyoutube")]
    public class AccYoutubeModel : EntityModel<AccYoutubeModel, long>
    {
        [Field]
        public string email { get; set; }
        [Field]
        public string pass { get; set; }
        [Field]
        public bool IsActice { get; set; }

    }
    public class AccYoutubeService : EntityService<AccYoutubeService, AccYoutubeModel>
    {
        public AccYoutubeService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
