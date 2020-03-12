using AZCore.Database;
using AZCore.Database.SQL;
using BotYoutube.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotYoutube.Entities
{
    public class DBCreateEntities : EntityService<DBCreateEntities>
    {
        public DBCreateEntities(IDbConnection _connection) : base(_connection)
        {
        }

        public void CheckDatabase()
        {
            //    this.BeginTransaction();
            foreach (var item in this.GetType().GetTypeFromInterface<IEntityModel>())
            {
                if(item.FullName.Contains("Entities"))
                    Execute(BuildSQL.NewSQL(item).CreateTableIfNotExit());
            }
            //  this.Commit();
        }
    }
}
