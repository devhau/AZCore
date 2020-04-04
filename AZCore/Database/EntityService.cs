using AZCore.Database.SQL;
using Dapper;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AZCore.Database
{
    public interface IEntityService 
    { }
    public class EntityService: IEntityService
    {
        private TypeSQL typeSQL;
        protected IDbConnection Connection;
        public EntityService(IDbConnection _connection)
        {
            Connection = _connection;
            CheckTypeSQL();
        }
        protected int? commandTimeout = null;
        protected IDbTransaction transaction = null;

        private void CheckTypeSQL() {
            string name = Connection.GetType().FullName;
            if (name.EndsWith(".SqlConnection"))
            {
                typeSQL = TypeSQL.SqlServer;
            }
            else if (name.EndsWith(".MySqlConnection"))
            {
                typeSQL = TypeSQL.MySql;
            }
        }
        public void BeginTransaction()
        {
            this.transaction = this.Connection.BeginTransaction();
        }
        public void Commit()
        {
            if (this.transaction != null) { this.transaction.Commit(); this.transaction = null; }

        }
        public void Rollback()
        {
            if (this.transaction != null) { this.transaction.Rollback(); this.transaction = null; }
        }
        public IDataReader ExecuteReader(SQLResult rs)
        {
            return ExecuteReader(rs.SQL, rs.Param);
        }
        protected IDataReader ExecuteReader(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.ExecuteReader(sql, param, this.transaction, commandTimeout, commandType);
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
        public SQLResult Query(string tablename, Action<QuerySQL> action) {

            var query = QuerySQL.NewQuery(this.typeSQL);
            query.SetTable(tablename);
            if (action != null) {
                action(query);
            }
            return query.ToResult();
        }
    }
    public partial class EntityService<TService, TModel> : EntityService
        where TService : EntityService
        where TModel : IEntityModel
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
        public IEnumerable<TModel> ExecuteQuery(Action<QuerySQL> action)
        {
            return ExecuteQuery(Query(action));
        }
        public long ExecuteNoneQuery(Action<QuerySQL> action, long @default =-1)
        {
            var reader = ExecuteReader(Query(action));
            var rs = @default;
            if (reader.Read())
            {
                rs= reader.GetInt64(0);
            }
            reader.Close();
            reader = null;
            return rs;
        }
        public SQLResult Query(Action<QuerySQL> action)
        {
            return Query(this.buildSQL.TableName, action);
        }
        public virtual IEnumerable<TModel> GetAll()
        {
            return ExecuteQuery(buildSQL.SQLSelect());
        }
        public virtual int Insert(TModel model)
        {
            return Execute(buildSQL.SQLInsert(model));
        }
        public virtual int Update(TModel model)
        {
            return Execute(buildSQL.SQLUpdate(model));
        }
        public virtual int Delete(TModel model)
        {
            return Execute(buildSQL.SQLDelete(model));
        }
        public virtual TModel GetById(object id) 
        {
            var rs = buildSQL.SQLSelect();
            rs.SQL = rs.SQL + " where `Id` = @Id";
            rs.Param.Add("@Id",id);
            return ExecuteQuery(rs).FirstOrDefault(); 
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
