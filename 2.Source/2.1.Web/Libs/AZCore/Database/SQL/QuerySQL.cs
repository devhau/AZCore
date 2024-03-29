﻿using AZCore.Database.Attributes;
using AZCore.Database.Enums;
using AZCore.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AZCore.Database.SQL
{

    public class QuerySQL
    {
        public List<TableInfo> Tables = new List<TableInfo>();
        public class TableInfo {
            public TableInfo(string TableName, List<TableInfo> Tables) {
                this.TableName = TableName;
                this.Tables = Tables;
                this.Index = this.Tables.Count;
            }
            public TableInfo(Type _modelType,  List<TableInfo> Tables)
            {
                this.ModelType = _modelType;
                this.TableName = _modelType.GetAttribute<TableInfoAttribute>().TableName;
                this.Tables = Tables;
                this.Index = this.Tables.Count;
            }
            public TableInfo AddToTables()
            {
                Tables.Add(this);
                return this;
            }
            public List<TableInfo> Tables { get; }
            public Type ModelType { get; set; }
            public string TableName { get;  }
            public int Index { get; }
            public string TIndex => "T{0}".Frmat(Index);
            public string GetColumn(string column)
            {
                if (column.Equals("*"))
                    return "{0}.{1}".Frmat(TIndex, column);
                PropertyInfo pro;
                if (ModelType != null && (pro = ModelType.GetProperty(column)) != null)
                {
                    var field = pro.GetAttribute<FieldTitleAttribute>();
                    if (field != null && field.TargetType != null && field.TargetColumn != null)
                    {
                        var table = this.Tables.FirstOrDefault(p => p.ModelType == field.TargetType);
                        return table.GetColumn(field.TargetColumn);
                    }
                }
                return "{0}.`{1}`".Frmat(TIndex, column);
            }
            public string GetColumn(string column,string asName) => "{0}.`{1}` as {2}".Frmat(TIndex, column, asName);
            public override string ToString()=> "`{0}` as {1}".Frmat(TableName, TIndex);
        }
        private class JoinTable
        {
            public bool IsOnly { get; set; }
            public TableInfo TableName { get; set; }
            public TableInfo TableName2 { get; set; }
            public Func<TableInfo, TableInfo, string> WhereJoin { get; set; }
            public JoinType JoinType { get; set; } = JoinType.InnerJoin;
        }
        private class ColumnValue {
            public ColumnValue() { }
            public ColumnValue(string column, object value) { this.Column = column; this.Value = value; }
            public ColumnValue(string column, object value, OperatorSQL _operator) { this.Column = column; this.Value = value; this.Operator = _operator; }
            public ColumnValue(string column, SortType sort) { this.Column = column;this.Sort = sort; }
            public TableInfo Table { get; set; }
            public TableInfo Table2 { get; set; }
            public string Column { get; set; }
            public object Value { get; set; }
            public SortType Sort { get; set; }
            public OperatorSQL Operator { get; set; }
            public List<ColumnValue> Sub { get; set; }
            public ColumnValue AddWhere<TModel2>(Func<QuerySQL, string> whereColumn, object value, OperatorSQL _operator = OperatorSQL.EQUAL)
            {
              //  this.SqlWhere.Add(new ColumnValue(whereColumn(this), value, _operator) { Table = GetTableInfo<TModel2>() ?? this.TableName });
                return this;
            }
            public ColumnValue AddWhere<TModel2>(string column, object value, OperatorSQL _operator = OperatorSQL.EQUAL)
            {
               // this.SqlWhere.Add(new ColumnValue(column, value, _operator) { Table = GetTableInfo<TModel2>() ?? this.TableName });
                return this;
            }
            public ColumnValue AddWhere(Func<QuerySQL, string> whereColumn, object value, OperatorSQL _operator = OperatorSQL.EQUAL, TableInfo table = null)
            {
               // this.SqlWhere.Add(new ColumnValue(whereColumn(this), value, _operator) { Table = table ?? this.TableName });
                return this;
            }
            public ColumnValue AddWhere(string column, object value, OperatorSQL _operator = OperatorSQL.EQUAL, TableInfo table = null)
            {
                //this.SqlWhere.Add(new ColumnValue(column, value, _operator) { Table = table ?? this.TableName });
                return this;
            }
            public string ToWhere(DynamicParameters parameter,int indexParam) {
                string nameColumn = Table.GetColumn(Column);
                string nameParam = "@{0}{1}".Frmat(Column.Replace('.','_'),indexParam);
                var itemOpera = this.Operator.GetAttributeByEnum<FieldAttribute>();
                parameter.Add(nameParam, itemOpera.GroupName.Frmat(this.Value));
                return itemOpera.Display.Frmat( nameParam, nameColumn);
            }
        }
        #region -- Init
        private TypeSQL type;
        private TableInfo TableName = null;
        private string Column = " * ";
        private List<JoinTable> joinTable = new List<JoinTable>();
        private List<ColumnValue> SqlWhere = new List<ColumnValue>();
        private List<ColumnValue> SqlOrder = new List<ColumnValue>();
        private List<ColumnValue> SqlGroup = new List<ColumnValue>();
        private List<ColumnValue> SqlHaving = new List<ColumnValue>();
        private int PageSize = 0;
        private int PageIndex = 0;       
        private QuerySQL(TypeSQL _type) {
            this.type = _type;
        }
        public static QuerySQL NewQuery()
        {
            return NewQuery(TypeSQL.MySql);
        }
        public static QuerySQL NewQuery(TypeSQL _type) {
            return new QuerySQL(_type);
        }
        #endregion
        public QuerySQL SetTable<TEntity>()
        {
            this.TableName = new TableInfo(typeof(TEntity), Tables).AddToTables();
            return this;
        }
        public QuerySQL SetTable(string name) {
            this.TableName = new TableInfo(name, Tables).AddToTables();
            return this;
        }
        public QuerySQL Join<TEntity>(Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            joinTable.Add(new JoinTable()
            {
                TableName = new TableInfo(typeof(TEntity), Tables).AddToTables(),
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL Join(string nameTable, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = new TableInfo(nameTable, Tables);
            Tables.Add(tb);
            joinTable.Add(new JoinTable() {
                TableName= tb,
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL Join<TEntity, TEntity2>(Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            joinTable.Add(new JoinTable()
            {
                TableName = new TableInfo(typeof(TEntity), Tables).AddToTables(),
                TableName2 = new TableInfo(typeof(TEntity2), Tables).AddToTables(),
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL Join(string nameTable, string nameTable2, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            joinTable.Add(new JoinTable()
            {
                TableName = new TableInfo(nameTable, Tables).AddToTables(),
                TableName2 = new TableInfo(nameTable2, Tables).AddToTables(),
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL JoinOnly<TEntity, TEntity2>(Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = Tables.FirstOrDefault(p => p.TableName == typeof(TEntity).GetAttribute<TableInfoAttribute>().TableName);
            if (tb == null)
            {
                tb = new TableInfo(typeof(TEntity), Tables).AddToTables();
                Tables.Add(tb);
            }
            joinTable.Add(new JoinTable()
            {
                TableName = tb,
                TableName2 = new TableInfo(typeof(TEntity2), Tables).AddToTables(),
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL JoinOnly(string nameTable, string nameTable2, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = Tables.FirstOrDefault(p=>p.TableName==nameTable);
            if (tb == null)
            {
                tb = new TableInfo(nameTable, Tables).AddToTables();
            }
            joinTable.Add(new JoinTable()
            {
                TableName = tb,
                TableName2 = new TableInfo(nameTable2, Tables).AddToTables(),
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public TableInfo GetTableInfo<TModel2>() {
            return this.Tables.FirstOrDefault(p => p.ModelType == typeof(TModel2));
        }
        public TableInfo GetTableInfo(string tableName)
        {
            return this.Tables.FirstOrDefault(p => p.TableName == tableName);
        }
        public QuerySQL SetColumn<TModel2>(Func<TableInfo,string> func)
        {
            this.Column = func(GetTableInfo<TModel2>());
            return this;
        }
        public QuerySQL AddColumn<TModel2>(Func<TableInfo, string> func)
        {
            if (this.Column.IsNullOrEmpty())
                this.Column = func(GetTableInfo<TModel2>());
            else
                this.Column += ", " + func(GetTableInfo<TModel2>());
            return this;
        }
        public QuerySQL SetColumn(string name)
        {
            this.Column = name;
            return this;
        }
        public QuerySQL AddColumn(string name)
        {
            if (this.Column.IsNullOrEmpty())
                this.Column = name;
            else
                this.Column += ", " + name;
            return this;
        }
        public QuerySQL AddWhere<TModel2>(Func<QuerySQL, string> whereColumn, object value, OperatorSQL _operator = OperatorSQL.EQUAL)
        {
            this.SqlWhere.Add(new ColumnValue(whereColumn(this), value, _operator) { Table = GetTableInfo<TModel2>() ?? this.TableName });
            return this;
        }
        public QuerySQL AddWhere<TModel2>(string column, object value, OperatorSQL _operator = OperatorSQL.EQUAL)
        {
            this.SqlWhere.Add(new ColumnValue(column, value, _operator) { Table = GetTableInfo<TModel2>() ?? this.TableName });
            return this;
        }
        public QuerySQL AddWhere(Func<QuerySQL, string> whereColumn, object value, OperatorSQL _operator = OperatorSQL.EQUAL,TableInfo table=null)
        {
            this.SqlWhere.Add(new ColumnValue(whereColumn(this), value, _operator) { Table = table ?? this.TableName });
            return this;
        }
        public QuerySQL AddWhere(string column, object value, OperatorSQL _operator=OperatorSQL.EQUAL, TableInfo table = null)
        {
            this.SqlWhere.Add(new ColumnValue(column,value, _operator) { Table = table ?? this.TableName });
            return this;
        }
        public QuerySQL AddOrder(string column, SortType sort, TableInfo table = null)
        {
            this.SqlOrder.Add(new ColumnValue(column, sort) { Table = table ?? this.TableName });
            return this;
        }
        public QuerySQL AddHaving(string column, object value, OperatorSQL _operator = OperatorSQL.EQUAL, TableInfo table = null)
        {
            this.SqlHaving.Add(new ColumnValue(column, value, _operator) {  Table = table ?? this.TableName });
            return this;

        }
        public QuerySQL AddGroup(string column, TableInfo table = null)
        {
            this.SqlGroup.Add(new ColumnValue() { Column = column, Table = table ?? this.TableName }) ;
            return this;
        }
        public QuerySQL Pagination(int pageIndex = 1, int pageSize = 20)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            return this;
        }
        public SQLResult ToResult() {

            StringBuilder sql = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            int indexParam = 0;
            sql.AppendFormat("SELECT {0} FROM {1}",this.Column,this.TableName);
            foreach (var item in this.joinTable) {
                string joinStr = " {0} ".Frmat(item.JoinType.GetAttributeByEnum<FieldAttribute>().Display);             
                if (item.TableName2.IsNull())
                    sql.AppendFormat(" {0} {1}  on {2}", joinStr, item.TableName, item.WhereJoin(this.TableName, item.TableName));
                else
                    sql.AppendFormat(" {0} {1}  on {2}", joinStr, item.TableName2, item.WhereJoin(item.TableName, item.TableName2));
            }
            if (SqlWhere.Count > 0) {
                sql.Append(" WHERE ");
                var flg =false;
                foreach (var item in SqlWhere) {
                    if (flg)
                        sql.Append(" AND ");
                    flg = true;
                    sql.Append(item.ToWhere(parameter,indexParam));
                    indexParam++;
                }
            }
            if (SqlGroup.Count > 0) {
                sql.Append(" GROUP BY ");
                bool first = true;
                foreach (var item in SqlGroup)
                {
                    if (!first)
                        sql.Append(" , ");
                    else
                        first = false;
                    sql.AppendFormat(" {0}", item.Column.Trim());
                }
            }
            if (SqlHaving.Count > 0)
            {
                sql.Append(" HAVING  ");
                var flg = false;
                foreach (var item in SqlHaving)
                {
                    if (flg)
                        sql.Append(" AND ");
                    flg = true;
                    sql.Append(item.ToWhere(parameter, indexParam));
                    indexParam++;
                }
            }
            if (SqlOrder.Count > 0)
            {
                sql.Append(" ORDER BY ");
                bool first = true;
                foreach (var item in SqlOrder)
                {
                    if (item.Sort == SortType.None) continue;
                    if (!first)
                        sql.Append(" , ");
                    else
                        first = false;
                    sql.AppendFormat(" {0} {1}", item.Column.Trim(), item.Sort.ToString());
                }
            }
            if (PageIndex > 0 && PageSize > 0) {
                int StartRow = (PageIndex - 1) * PageSize;
                if (type == TypeSQL.MySql)
                {
                    sql.AppendFormat(" LIMIT {0},{1} ", StartRow, PageSize);
                }
                else if(type==TypeSQL.SqlServer){
                    sql.AppendFormat(" offset {0} rows fetch next {1} rows only", StartRow+1, PageSize);
                }
            
            }
            return new SQLResult()
            {
                SQL = sql.ToString(),
                Param = parameter
            };
        }
    }
}
