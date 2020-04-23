using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Domain;
using AZCore.Extensions;
using AZWeb.Module.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AZERP.Data.Entities
{
    public class DBCreateEntities : EntityService, IDBCreate, IAZTransient
    {
        public DBCreateEntities(IDbConnection _connection) : base(_connection)
        {
        }

        public void CheckDatabase()
        {
        //    this.BeginTransaction();
            foreach (var item in this.GetType().GetTypeFromInterface<IEntity>()) {
                if (!item.IsTypeFromInterface<IModule>())
                {
                    try
                    {
                        Debug.WriteLine(item.Name);
                        Execute(BuildSQL.NewSQL(item).CreateTableIfNotExit());
                    }
                    catch {
                        throw new Exception("");
                    }
                }
            }
          //  this.Commit();
        }
    }
}
