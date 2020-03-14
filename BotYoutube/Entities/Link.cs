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
    [TableInfo(TableName = "bot_link")]
    public class LinkModel : EntityModel<LinkModel, long>
    {
        [Field]
        public string link { get; set; }
        [Field]
        public bool IsView { get; set; }
        [Field]
        public int DelayView { get; set; }
        [Field]
        public bool IsSub { get; set; }
        [Field]
        public int DelaySub { get; set; }
        [Field]
        public bool IsLike { get; set; }
        [Field]
        public int DelayLike { get; set; }
        [Field]
        public bool IsDisLike { get; set; }
        [Field]
        public int DelayDisLike { get; set; }
        [Field]
        public bool IsComment { get; set; }
        [Field]
        public int DelayComment { get; set; }
        [Field]
        public int Rank { get; set; }
        [Field]
        public int TargetView { get; set; }

    }
    public class LinkService : EntityService<LinkService, LinkModel>
    {
        public LinkService(IDbConnection _connection) : base(_connection)
        {
        }
    }
}
