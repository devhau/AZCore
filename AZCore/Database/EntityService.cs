using AZCore.Database.SQL;
using Dapper;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZCore.Database
{
    public class EntityService
    {
        protected IDbConnection Connection;
        public EntityService(IDbConnection _connection)
        {
            Connection = _connection;
        }
    }
    public class EntityService<TService> : EntityService where TService : EntityService
    {
        protected int? commandTimeout = null;
        protected IDbTransaction transaction = null;
        public void BeginTransaction() {
            this.transaction =  this.Connection.BeginTransaction();
        }
        public void Commit() {
            if (this.transaction!=null) { this.transaction.Commit(); this.transaction = null; }
            
        }
        public void Rollback()
        {
            if (this.transaction != null) { this.transaction.Rollback(); this.transaction = null; }
        }
        public EntityService(IDbConnection _connection) : base(_connection)
        {
        }
        public IDataReader ExecuteReader(SQLResult rs)
        {
            return ExecuteReader(rs.SQL, rs.Param);
        }
        protected IDataReader ExecuteReader(string sql,object param=null, CommandType? commandType = null) {
            return this.Connection.ExecuteReader(sql,param, this.transaction, commandTimeout, commandType);
        }
        public int Execute(SQLResult rs)
        {
            return Execute(rs.SQL, rs.Param);
        }
        protected int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.Execute(sql, param, this.transaction, commandTimeout, commandType);
        }
        public async Task<IDataReader> ExecuteReaderAsync(SQLResult rs)
        {
            return await ExecuteReaderAsync(rs.SQL, rs.Param);
        }
        protected async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.ExecuteReaderAsync(sql, param, this.transaction, commandTimeout, commandType);
        }
        public async Task<int> ExecuteAsync(SQLResult rs)
        {
            return await ExecuteAsync(rs.SQL, rs.Param);
        }
        protected async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.ExecuteAsync(sql, param, this.transaction, commandTimeout, commandType);
        }
    }
    public partial class EntityService<TService, TModel> : EntityService<TService>
        where TService : EntityService<TService>
        where TModel : EntityModel
    {
        protected BuildSQL buildSQL;
        public EntityService(IDbConnection _connection) : base(_connection)
        {
            buildSQL = BuildSQL.NewSQL(typeof(TModel));
        }
        public IEnumerable<TModel> ExecuteQuery(SQLResult rs) {
            return ExecuteQuery(rs.SQL, rs.Param);
        }
        public IEnumerable<TModel> ExecuteQuery(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.Query<TModel>(sql, param, this.transaction, true, this.commandTimeout, commandType);
        }
        public async Task<IEnumerable<TModel>> ExecuteQueryAsync(SQLResult rs)
        {
            return await ExecuteQueryAsync(rs.SQL, rs.Param);
        }
        public async Task<IEnumerable<TModel>> ExecuteQueryAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.QueryAsync<TModel>(sql, param, this.transaction, this.commandTimeout, commandType);
        }
        public IEnumerable<TModel> GetAll()
        {
            return ExecuteQuery(buildSQL.SQLSelect());
        }
        public int Insert(TModel model)
        {
            return Execute(buildSQL.SQLInsert(model));
        }
        public int Update(TModel model)
        {
            return Execute(buildSQL.SQLUpdate(model));
        }
        public int Delete(TModel model)
        {
            return Execute(buildSQL.SQLDelete(model));
        }
    }
    public partial class EntityService<TService, TModel> {
        public IEnumerable<TModel> Select(Expression<Func<TModel, bool>> funcWhere)
        {
            return ExecuteQuery(buildSQL.SQLSelect(funcWhere));
        }
        public int Update(Expression<Func<TModel, bool>> updateSet, Expression<Func<TModel, bool>> funcWhere)
        {
            return Execute(buildSQL.SQLUpdate(updateSet, funcWhere));
        }
        public int Delete(Expression<Func<TModel, bool>> funcWhere)
        {
            return Execute(buildSQL.SQLDelete(funcWhere));
        }
    }
}
