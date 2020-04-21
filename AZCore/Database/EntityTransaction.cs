using System;
using System.Data;
using AZCore.Extensions;
namespace AZCore.Database
{
    public class EntityTransaction
    {
        public IDbConnection Connection;
        public IDbTransaction Transaction = null;
        public EntityTransaction(IDbConnection _connection)
        {
            Connection = _connection;
        }
        public void BeginTransaction()
        {
            if (this.Connection.State != ConnectionState.Open)
            {
                this.Connection.Open();
            }
            this.Transaction = this.Connection.BeginTransaction();
        }
        public void Commit()
        {
            if (this.Transaction != null) { this.Transaction.Commit(); this.Transaction.Dispose(); this.Transaction = null; }

        }
        public void Rollback()
        {
            if (this.Transaction != null) { this.Transaction.Rollback(); this.Transaction.Dispose(); this.Transaction = null; }
        }

        #region TService1
        public bool DoTransantion<TService1>(Action<EntityTransaction, TService1> action, bool isThrow = false)
                where TService1 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection));
                this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService2
        public bool DoTransantion<TService1, TService2>(Action<EntityTransaction, TService1, TService2> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection), typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection));
                this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService3
        public bool DoTransantion<TService1, TService2, TService3>(Action<EntityTransaction, TService1, TService2, TService3> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection), typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection), typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection));
                this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService4
        public bool DoTransantion<TService1, TService2, TService3, TService4>(Action<EntityTransaction, TService1, TService2, TService3, TService4> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                    , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                    , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                    , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                    );
                this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService5
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService6
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
                where TService6 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService6).CreateInstance<TService6>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService7
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
                where TService6 : EntityService
                where TService7 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService6).CreateInstance<TService6>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService7).CreateInstance<TService7>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService8
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
                where TService6 : EntityService
                where TService7 : EntityService
                where TService8 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this
                     , typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService6).CreateInstance<TService6>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService7).CreateInstance<TService7>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService8).CreateInstance<TService8>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService9
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
                where TService6 : EntityService
                where TService7 : EntityService
                where TService8 : EntityService
                where TService9 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this
                     , typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService6).CreateInstance<TService6>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService7).CreateInstance<TService7>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService8).CreateInstance<TService8>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService9).CreateInstance<TService9>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion

        #region TService9
        public bool DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9, TService10>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9, TService10> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
                where TService6 : EntityService
                where TService7 : EntityService
                where TService8 : EntityService
                where TService9 : EntityService
                where TService10 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this
                     , typeof(TService1).CreateInstance<TService1>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService2).CreateInstance<TService2>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService3).CreateInstance<TService3>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService4).CreateInstance<TService4>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService5).CreateInstance<TService5>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService6).CreateInstance<TService6>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService7).CreateInstance<TService7>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService8).CreateInstance<TService8>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService9).CreateInstance<TService9>((t)=>  t.Transaction = Transaction,this.Connection)
                     , typeof(TService10).CreateInstance<TService10>((t)=>  t.Transaction = Transaction,this.Connection)
                     ); this.Commit();return true;
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex; return false;
            }

        }
        #endregion
    }
}
