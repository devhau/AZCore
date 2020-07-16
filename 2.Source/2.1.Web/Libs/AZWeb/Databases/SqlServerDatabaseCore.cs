using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Databases
{
    public class SqlServerDatabaseCore : DatabaseCore
    {
        public SqlServerDatabaseCore(string connectString) : base(connectString)
        {
            this.Type = TypeSQL.SqlServer;
        }

        public override IDbConnection CreateConnection()
        {
            return null;
        }
    }
}
