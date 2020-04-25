﻿using AZCore.Database.Enums;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.SQL
{

    public class QuerySQL
    {

        private class JoinTable
        {
            public string TableName { get; set; }
            public Func<string, string, string> WhereJoin { get; set; }
            public JoinType JoinType { get; set; } = JoinType.InnerJoin;
        }
        private class ColumnValue {
            public ColumnValue() { }
            public ColumnValue(string column, object value) { this.Column = column; this.Value = value; }
            public ColumnValue(string column, object value, OperatorSQL _operator) { this.Column = column; this.Value = value; this.Operator = _operator; }
            public ColumnValue(string column, SortType sort) { this.Column = column;this.Sort = sort; }
            public string Column { get; set; }
            public object Value { get; set; }
            public SortType Sort { get; set; }
            public OperatorSQL Operator { get; set; }
            public List<ColumnValue> Sub { get; set; }
        }
        #region -- Init
        private TypeSQL type;
        private string TableName = "";
        private string Column = " * ";
        private List<JoinTable> joinTable = new List<JoinTable>();
        private List<ColumnValue> SqlWhere = new List<ColumnValue>();
        private List<ColumnValue> SqlOrder = new List<ColumnValue>();
        private List<ColumnValue> SqlGroup = new List<ColumnValue>();
        private int PageSize = 0;
        private int PageIndex = 0;       
        private QuerySQL(TypeSQL _type) {
            this.type = _type;
        }
        public static QuerySQL NewQuery(TypeSQL _type) {
            return new QuerySQL(_type);
        }
        #endregion
        
        public QuerySQL SetTable(string name) {
            this.TableName = name;
            return this;
        }
        public QuerySQL Join(string nameTable, Func<string, string, string> whereJoin, JoinType joinType = JoinType.InnerJoin)
        {
            joinTable.Add(new JoinTable() {
                TableName= nameTable,
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
        public QuerySQL AddWhere(string column, object value, OperatorSQL _operator=OperatorSQL.EQUAL)
        {
            this.SqlWhere.Add(new ColumnValue(column,value, _operator));
            return this;
        }
        public QuerySQL AddOrder(string column, SortType sort)
        {
            this.SqlOrder.Add(new ColumnValue(column, sort));
            return this;
        }
        public QuerySQL AddGroup(string column)
        {
            this.SqlOrder.Add(new ColumnValue() { Column= column });
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
            sql.AppendFormat("SELECT {0} FROM `{1}` ",this.Column,this.TableName);
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
                sql.AppendFormat(" {0} `{1}`  on {2}", joinStr,item.TableName,item.WhereJoin(this.TableName,item.TableName));
            }
            if (SqlWhere.Count > 0) {
                int indexWhere = 0;
                sql.Append(" WHERE ");
                foreach (var item in SqlWhere) {
                    if (indexWhere > 0)
                        sql.Append(" AND ");

                    switch (item.Operator) {
                        case OperatorSQL.LIKE:
                            sql.AppendFormat(" `{0}` like @{0}{1} ", item.Column.Trim(), indexWhere);
                            parameter.Add(string.Format("@{0}{1}", item.Column.Trim(), indexWhere), string.Format("%{0}%", item.Value));
                            break;
                        case OperatorSQL.IN:
                            sql.AppendFormat(" `{0}` in (@{0}{1}) ", item.Column.Trim(), indexWhere);
                            parameter.Add(string.Format("@{0}{1}", item.Column.Trim(), indexWhere), item.Value);
                            break;

                        default:
                            sql.AppendFormat(" `{0}` = @{0}{1} ", item.Column.Trim(), indexWhere);
                            parameter.Add(string.Format("@{0}{1}", item.Column.Trim(), indexWhere), item.Value);
                            break;
                    }
                    indexWhere++;
                }
            }
            if (SqlOrder.Count > 0) {
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
            if (SqlGroup.Count > 0) {
                sql.Append(" ORDER BY ");
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
