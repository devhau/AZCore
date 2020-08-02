using AZCore.Database.Attributes;
using AZCore.Database.Enums;
using AZCore.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AZCore.Database.SQL
{

    public class QuerySQL
    {
        public List<TableInfo> Tables = new List<TableInfo>();
        public class TableInfo {
            public TableInfo(string TableName,int Index) {
                this.TableName = TableName;
                this.Index = Index;
            }
            public string TableName { get;  }
            public int Index { get; }
            public string TIndex => "T{0}".Frmat(Index);
            public string GetColumn(string column) => column.Equals("*")? "{0}.{1}".Frmat(TIndex, column) : "{0}.`{1}`".Frmat(TIndex, column);
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
            public string Column { get; set; }
            public object Value { get; set; }
            public SortType Sort { get; set; }
            public OperatorSQL Operator { get; set; }
            public List<ColumnValue> Sub { get; set; }
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
            return new QuerySQL(TypeSQL.MySql);
        }
        public static QuerySQL NewQuery(TypeSQL _type) {
            return new QuerySQL(_type);
        }
        #endregion
        public QuerySQL SetTable<TEntity>()
        {
            return SetTable(typeof(TEntity).GetAttribute<TableInfoAttribute>().TableName);
        }
        public QuerySQL SetTable(string name) {
            var tb = new TableInfo(name, Tables.Count);
            Tables.Add(tb);
            this.TableName = tb;
            return this;
        }
        public QuerySQL Join<TEntity>(Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin) 
        {
            return Join(typeof(TEntity).GetAttribute<TableInfoAttribute>().TableName,whereJoin, joinType);
        }
        public QuerySQL Join(string nameTable, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = new TableInfo(nameTable, Tables.Count);
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
            return Join(typeof(TEntity).GetAttribute<TableInfoAttribute>().TableName, typeof(TEntity2).GetAttribute<TableInfoAttribute>().TableName, whereJoin, joinType);
        }
        public QuerySQL Join(string nameTable, string nameTable2, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = new TableInfo(nameTable, Tables.Count);
            Tables.Add(tb);
            var tb2 = new TableInfo(nameTable2, Tables.Count);
            Tables.Add(tb2);
            joinTable.Add(new JoinTable()
            {
                TableName2= tb2,
                TableName = tb,
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
            return this;
        }
        public QuerySQL JoinOnly<TEntity, TEntity2>(Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            return JoinOnly(typeof(TEntity).GetAttribute<TableInfoAttribute>().TableName, typeof(TEntity2).GetAttribute<TableInfoAttribute>().TableName, whereJoin, joinType);
        }
        public QuerySQL JoinOnly(string nameTable, string nameTable2, Func<TableInfo, TableInfo, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            var tb = Tables.FirstOrDefault(p=>p.TableName==nameTable);
            if (tb == null)
            {
                tb = new TableInfo(nameTable, Tables.Count);
                Tables.Add(tb);
            }
            var tb2 = new TableInfo(nameTable2, Tables.Count);
            Tables.Add(tb2);
            joinTable.Add(new JoinTable()
            {
                TableName2 = tb2,
                TableName = tb,
                WhereJoin = whereJoin,
                JoinType = joinType,
            });
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
                string joinStr = " JOIN ";
                if (item.JoinType == JoinType.LeftOuterJoin) {
                    joinStr = " LEFT JOIN ";
                }
                if (item.JoinType == JoinType.RightOuterJoin){
                    joinStr = " RIGHT JOIN ";
                }
                if (item.JoinType == JoinType.RightOuterJoin){
                    joinStr = " FULL OUTER JOIN ";
                }
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
