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

    }
    public class AccYoutubeService : EntityService<AccYoutubeService, AccYoutubeModel>
    {
        public AccYoutubeService(IDbConnection _connection) : base(_connection)
        {
        }
        public AccYoutubeModel GetAccProcess() {
            var sqlLink = this.buildSQL.SQLSelect();
            var sqlWhere = " where IsActive = 1 order by UpdateAt";
            sqlLink.SQL = sqlLink.SQL + sqlWhere;
            var rs = ExecuteQuery(sqlLink).FirstOrDefault();
            if (rs != null)
            {
                rs.UpdateAt = DateTime.Now;
                this.Update(rs);
            }
            return rs;
        }
    }
}
