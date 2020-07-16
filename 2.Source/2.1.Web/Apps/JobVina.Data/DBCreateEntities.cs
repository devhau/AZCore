using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Domain;
using AZCore.Extensions;
using AZWeb.Module.Common;
using System;
using System.Data;

namespace JobVina.Data
{
    public class DBCreateEntities : EntityService, IDBCreate, IAZTransient
    {
        public DBCreateEntities(IDatabaseCore databaseCore) : base(databaseCore)
        {
        }

        public void CheckEmptyAndCreateDatabase()
        {
        //    this.BeginTransaction();
            foreach (var item in this.GetType().GetTypeFromInterface<IEntity>()) {
                if (!item.IsTypeFromInterface<IModule>())
                {
                    try
                    {
                        Execute(BuildSQL.NewSQL(item).CreateTableIfNotExit());
                    }
                    catch(Exception ex) {
                        throw new Exception(ex.Message);
                    }
                }
            }
          //  this.Commit();
        }
    }
}
