using AZCore.Database.Attr;
using AZCore.Database.SQL;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
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
    public class EntityBase<TEntity, TKey> : EntityBase<TEntity>  where TEntity : EntityBase
    {
        public EntityBase(IDbConnection _connection) : base(_connection)
        {
        }
        [Field(IsKey = true)]
        public virtual TKey Id { get; set; }
        
    }
    public class EntityBase<TEntity> : EntityNoneBase<TEntity> where TEntity : EntityBase
    {
        public EntityBase(IDbConnection _connection) : base(_connection)
        {
        }

        [Field]
        public bool IsActive { get; set; }
        [Field]
        public bool IsDelete { get; set; }
        [Field]
        public DateTime CreateAt { get; set; }
        [Field]
        public DateTime? UpdateAt { get; set; }
        [Field]
        public DateTime? DeleteAt { get; set; }
    }
    public class EntityNoneBase<TEntity> : EntityBase where TEntity : EntityBase
    {
        protected int? commandTimeout = null;
        protected IDbTransaction transaction = null;
        protected EntitySQL builder = null;

        public EntityNoneBase(IDbConnection _connection) : base(_connection)
        {
            this.builder = EntitySQL.NewSQL(this);
        }

        public IEnumerable<TEntity> Select(Expression<Func<TEntity,bool>> func)
        {
            return null;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return null;
        }
        public async Task<bool> Insert() {
            var rs = this.builder.ToSqlInsert();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param) > 0;

        }
        public async Task<bool> Update()
        {
            var rs = this.builder.ToSqlUpdate();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param) > 0;
        }
        public async Task<bool> Update(Expression<Func<TEntity, bool>> updateSet, Expression<Func<TEntity, bool>> funcWhere)
        {
            var rs = this.builder.ToSqlUpdate();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param) > 0;
        }
        public async Task<bool> Delete()
        {
            var rs = this.builder.ToSqlDelete();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param) > 0;
        }
        public async Task<bool> Delete(Expression<Func<TEntity, bool>> funcWhere)
        {
            var rs = this.builder.ToSqlDelete();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param) > 0;
        }
        public async Task<bool> CreateTableIfNotExitAsync() {
            var rs = this.builder.CreateTableIfNotExit();
            return await this.ExeNonQueryAsync(rs.SQL, rs.Param)>0;
        }
        protected Task<IEnumerable<TEntity2>> ExeQueryAsync<TEntity2>( string sql, object param)
        {
            return this.Connection.QueryAsync<TEntity2>(sql, param, transaction, commandTimeout, CommandType.Text);
        }
        protected Task<int> ExeNonQueryAsync(string sql, object param) {
            return this.Connection.ExecuteAsync(sql, param, transaction, commandTimeout, CommandType.Text);
        }
        protected Task<IEnumerable<TEntity>> ExeStoreyAsync(string sql, object param)
        {
            return this.Connection.QueryAsync<TEntity>(sql, param, transaction, commandTimeout, CommandType.StoredProcedure);
        }
        protected Task<int> ExeNonStoreAsync(string sql, object param)
        {
            return this.Connection.ExecuteAsync(sql, param, transaction, commandTimeout, CommandType.StoredProcedure);
        }
    }
}
