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

    }
    public class ProxyService : EntityService<ProxyService, ProxyModel>
    {
        public ProxyService(IDbConnection _connection) : base(_connection)
        {
        }
        public ProxyModel GetProxyProcess() {
            var sqlLink = this.buildSQL.SQLSelect();
            var sqlWhere = " where IsUse = 0 and IsActive = 1 order by UpdateAt";
            sqlLink.SQL = sqlLink.SQL + sqlWhere;
            var rs = ExecuteQuery(sqlLink).FirstOrDefault();
            if (rs != null)
            {
                rs.IsUse = true;
                rs.UpdateAt = DateTime.Now;
                this.Update(rs);
            }
            return  rs;
        }
    }
}
