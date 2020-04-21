﻿using System;
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
        public void DoTransantion<TService1>(Action<EntityTransaction, TService1> action, bool isThrow = false)
                where TService1 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection));
                this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService2
        public void DoTransantion<TService1, TService2>(Action<EntityTransaction, TService1, TService2> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection), typeof(TService2).CreateInstance<TService2>(this.Connection));
                this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService3
        public void DoTransantion<TService1, TService2, TService3>(Action<EntityTransaction, TService1, TService2, TService3> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection), typeof(TService2).CreateInstance<TService2>(this.Connection), typeof(TService3).CreateInstance<TService3>(this.Connection));
                this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService4
        public void DoTransantion<TService1, TService2, TService3, TService4>(Action<EntityTransaction, TService1, TService2, TService3, TService4> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection)
                    , typeof(TService2).CreateInstance<TService2>(this.Connection)
                    , typeof(TService3).CreateInstance<TService3>(this.Connection)
                    , typeof(TService4).CreateInstance<TService4>(this.Connection)
                    );
                this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService5
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5> action, bool isThrow = false)
                where TService1 : EntityService
                where TService2 : EntityService
                where TService3 : EntityService
                where TService4 : EntityService
                where TService5 : EntityService
        {
            this.BeginTransaction();
            try
            {
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService6
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6> action, bool isThrow = false)
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
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     , typeof(TService6).CreateInstance<TService6>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService7
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7> action, bool isThrow = false)
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
                action?.Invoke(this, typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     , typeof(TService6).CreateInstance<TService6>(this.Connection)
                     , typeof(TService7).CreateInstance<TService7>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService8
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8> action, bool isThrow = false)
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
                     , typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     , typeof(TService6).CreateInstance<TService6>(this.Connection)
                     , typeof(TService7).CreateInstance<TService7>(this.Connection)
                     , typeof(TService8).CreateInstance<TService8>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService9
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9> action, bool isThrow = false)
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
                     , typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     , typeof(TService6).CreateInstance<TService6>(this.Connection)
                     , typeof(TService7).CreateInstance<TService7>(this.Connection)
                     , typeof(TService8).CreateInstance<TService8>(this.Connection)
                     , typeof(TService9).CreateInstance<TService9>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion

        #region TService9
        public void DoTransantion<TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9, TService10>(Action<EntityTransaction, TService1, TService2, TService3, TService4, TService5, TService6, TService7, TService8, TService9, TService10> action, bool isThrow = false)
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
                     , typeof(TService1).CreateInstance<TService1>(this.Connection)
                     , typeof(TService2).CreateInstance<TService2>(this.Connection)
                     , typeof(TService3).CreateInstance<TService3>(this.Connection)
                     , typeof(TService4).CreateInstance<TService4>(this.Connection)
                     , typeof(TService5).CreateInstance<TService5>(this.Connection)
                     , typeof(TService6).CreateInstance<TService6>(this.Connection)
                     , typeof(TService7).CreateInstance<TService7>(this.Connection)
                     , typeof(TService8).CreateInstance<TService8>(this.Connection)
                     , typeof(TService9).CreateInstance<TService9>(this.Connection)
                     , typeof(TService10).CreateInstance<TService10>(this.Connection)
                     ); this.Commit();
            }
            catch (Exception ex)
            {
                this.Rollback();
                if (isThrow) throw ex;
            }

        }
        #endregion
    }
}
