using AZCore.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AZWeb.Databases
{
    public class MySQLDatabaseCore : DatabaseCore
    {
        public MySQLDatabaseCore(string connectString) : base(connectString)
        {
            this.Type = TypeSQL.MySql;
        }

        public override IDbConnection CreateConnection()
        {
            
            return new MySql.Data.MySqlClient.MySqlConnection(this._connectString);
        }
    }
}
