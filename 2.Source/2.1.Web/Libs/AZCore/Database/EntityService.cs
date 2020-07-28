using AZCore.Database.SQL;
using AZCore.Extensions;
using Dapper;
using Org.BouncyCastle.Math.Field;
using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AZCore.Database
{
    public interface IEntityService:IDisposable
    { }
    public class EntityService: IEntityService
    {
        protected TypeSQL typeSQL;
        public IDbConnection Connection => _databaseCore.Connection;
        protected readonly IDatabaseCore _databaseCore;
        public IDbTransaction Transaction = null;
        public EntityService(IDatabaseCore databaseCore)
        {
            _databaseCore = databaseCore;
        }
        protected int? commandTimeout = null;
        public void BeginTransaction()
        {
            if (this.Connection.State != ConnectionState.Open) {
                this.Connection.Open();
            }
            this.Transaction = this.Connection.BeginTransaction();
        }
        public void Commit()
        {
            if (this.Transaction != null) { this.Transaction.Commit(); this.Transaction = null; }

        }
        public void Rollback()
        {
            if (this.Transaction != null) { this.Transaction.Rollback(); this.Transaction = null; }
        }
        public IDataReader ExecuteReader(SQLResult rs)
        {
            return ExecuteReader(rs.SQL, rs.Param);
        }
        protected IDataReader ExecuteReader(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.ExecuteReader(sql, param, this.Transaction, commandTimeout, commandType);
        }
        public int Execute(SQLResult rs)
        {
            return Execute(rs.SQL, rs.Param);
        }
        protected int Execute(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.Execute(sql, param, this.Transaction, commandTimeout, commandType);
        }
        public async Task<IDataReader> ExecuteReaderAsync(SQLResult rs)
        {
            return await ExecuteReaderAsync(rs.SQL, rs.Param);
        }
        protected async Task<IDataReader> ExecuteReaderAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.ExecuteReaderAsync(sql, param, this.Transaction, commandTimeout, commandType);
        }
        public async Task<int> ExecuteAsync(SQLResult rs)
        {
            return await ExecuteAsync(rs.SQL, rs.Param);
        }
        protected async Task<int> ExecuteAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.ExecuteAsync(sql, param, this.Transaction, commandTimeout, commandType);
        }
        public SQLResult Query(string tablename, Action<QuerySQL> action) {

            var query = QuerySQL.NewQuery(this.typeSQL);
            query.SetTable(tablename);
            if (action != null) {
                action(query);
            }
            return query.ToResult();
        }

        public virtual void Dispose()
        {
           if (_databaseCore!=null&&_databaseCore.IsDisposable)
            {
                if (Transaction != null)
                {
                    Transaction.Dispose();
                    Transaction = null;
                }
                this._databaseCore.Dispose();
            }
        }
    }
    public partial class EntityService<TService, TModel> : EntityService
        where TService : EntityService<TService, TModel>
        where TModel : IEntity
    {
        protected BuildSQL buildSQL;
        public EntityService(IDatabaseCore databaseCore) : base(databaseCore)
        {
            buildSQL = BuildSQL.NewSQL(typeof(TModel));
            buildSQL.typeSQL = databaseCore.Type;
        }
        public IEnumerable<TModel1> ExecuteQuery<TModel1>(SQLResult rs)
        {
            return ExecuteQuery<TModel1>(rs.SQL, rs.Param);
        }
        public IEnumerable<TModel1> ExecuteQuery<TModel1>(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.Query<TModel1>(sql, param, this.Transaction, true, this.commandTimeout, commandType);
        }
        public IEnumerable<TModel> ExecuteQuery(SQLResult rs) {
            return ExecuteQuery(rs.SQL, rs.Param);
        }
        public IEnumerable<TModel> ExecuteQuery(string sql, object param = null, CommandType? commandType = null)
        {
            return this.Connection.Query<TModel>(sql, param, this.Transaction, true, this.commandTimeout, commandType);
        }
        public async Task<IEnumerable<TModel>> ExecuteQueryAsync(SQLResult rs)
        {
            return await ExecuteQueryAsync(rs.SQL, rs.Param);
        }
        public async Task<IEnumerable<TModel>> ExecuteQueryAsync(string sql, object param = null, CommandType? commandType = null)
        {
            return await this.Connection.QueryAsync<TModel>(sql, param, this.Transaction, this.commandTimeout, commandType);
        }
        public async Task<IEnumerable<TModel>> ExecuteQueryAsync(Action<QuerySQL> action)
        {
            return await ExecuteQueryAsync(Query(action));
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
        public virtual long Insert(TModel model)
        {
            var rs = buildSQL.SQLInsert(model);
            return this.Connection.Query<long>(rs.SQL, rs.Param, this.Transaction).Single();
        }
        public virtual int InsertRange(IEnumerable<TModel> models)
        {
            int count = 0;
            foreach (var model in models)
            {
                count += Execute(buildSQL.SQLInsert(model));
            }
            return count;
        }
        public virtual int Update(TModel model)
        {
            return Execute(buildSQL.SQLUpdate(model));
        }
        public virtual int UpdateRange(IEnumerable<TModel> models)
        {
            int count = 0;
            foreach (var model in models)
            {
                count += Execute(buildSQL.SQLUpdate(model));
            }
            return count;
        }
        public virtual int Delete(TModel model)
        {
            return Execute(buildSQL.SQLDelete(model));
        }
        public virtual int DeleteRange(IEnumerable<TModel> models)
        {
            int count = 0;
            foreach (var model in models)
            {
                count += Execute(buildSQL.SQLDelete(model));
            }
            return count;
        }
        public virtual TModel GetById(object id) 
        {
            var rs = buildSQL.SQLSelect();
            rs.SQL = rs.SQL + " where `Id` = @Id";
            rs.Param.Add("@Id",id);
            return ExecuteQuery(rs).FirstOrDefault(); 
        }
        public override void Dispose()
        {
            base.Dispose();

            if (this.buildSQL != null)
            {
                this.buildSQL.Dispose();
            }
        }
    }
    public partial class EntityService<TService, TModel> {
        public IEnumerable<TModel> SelectObject(Expression<Func<Object, bool>> funcWhere)
        {
            return this.Select(funcWhere.ConvertTo<object,TModel>());
        }
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
