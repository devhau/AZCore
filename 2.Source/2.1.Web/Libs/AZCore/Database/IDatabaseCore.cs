using Org.BouncyCastle.Math.Field;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AZCore.Database
{
    public interface IDatabaseCore : IDisposable
    {
        bool IsDisposable { get; set; }
        TypeSQL Type { get; set; }
        IDbConnection Connection { get; }
        IDbConnection CreateConnection();
    }
    public abstract class DatabaseCore : IDatabaseCore
    {
        public bool IsDisposable { get; set; } = true;
        public TypeSQL Type { get; set; } = TypeSQL.None;
        protected string _connectString;
        IDbConnection _connection;
        public DatabaseCore(string connectString) { this._connectString = connectString; }
        public abstract IDbConnection CreateConnection();

        public virtual void Dispose()
        {
            if (IsDisposable)
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
        }

        public IDbConnection Connection => _connection ??= CreateConnection();
    }
}
