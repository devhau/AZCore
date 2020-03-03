using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Domain;
using AZCore.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AZ.Web.Entities
{
    public class DBCreateEntities : EntityService<DBCreateEntities>, IDBCreate, IAZTransient
    {
        public DBCreateEntities(IDbConnection _connection) : base(_connection)
        {
        }

        public void CheckDatabase()
        {
        //    this.BeginTransaction();
            foreach (var item in this.GetType().GetTypeFromInterface<IEntityModel>()) {
                Execute(BuildSQL.NewSQL(item).CreateTableIfNotExit());
               
            }
          //  this.Commit();
        }
    }
}
