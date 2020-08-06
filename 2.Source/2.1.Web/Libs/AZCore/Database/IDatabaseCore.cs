using System;
using System.Data;

namespace AZCore.Database
{
    public interface IDatabaseCore : IDisposable
    {
        bool IsDisposable { get; set; }
        TypeSQL Type { get; set; }
        IDbConnection Connection { get; }
        IDbConnection CreateConnection();
        IDatabaseCore Clone();
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
        public virtual IDatabaseCore Clone() {
            return (IDatabaseCore)Activator.CreateInstance(this.GetType(), this._connectString);
        }
    }
}
