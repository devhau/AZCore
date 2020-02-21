using AZCore.Database.SQL;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace AZCore.Database
{
    public class EntityBase
    {
        protected IDbConnection Connection;
        public EntityBase(IDbConnection _connection) {
            Connection = _connection;
        }
    }
    public class EntityBase<TEntity> : EntityBase where TEntity : EntityBase
    {
        private EntitySQL sql;
        public EntityBase(IDbConnection _connection) : base(_connection)
        {
            this.sql = EntitySQL.NewSQL(this);
        }
        public Task<IEnumerable<TEntity>> QueryAsync( string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return this.Connection.QueryAsync<TEntity>(sql, param, transaction, commandTimeout, commandType);
        }
        public Task<int> Execute(string sql, object param, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null) {
            return this.Connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }
    }
}
