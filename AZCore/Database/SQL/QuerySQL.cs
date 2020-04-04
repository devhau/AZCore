using Dapper;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Database.SQL
{
    public class QuerySQL
    {
        
        private class ColumnValue {
            public ColumnValue() { }
            public ColumnValue(string column, object value) { this.Column = column; this.Value = value; }
            public ColumnValue(string column, EnumSort sort) { this.Column = column;this.Sort = sort; }
            public string Column { get; set; }
            public object Value { get; set; }
            public EnumSort Sort { get; set; }
            public List<ColumnValue> Sub { get; set; }
        }
        #region -- Init
        private TypeSQL type;
        private string TableName = "";
        private string Column = " * ";
        private List<ColumnValue> SqlWhere = new List<ColumnValue>();
        private List<ColumnValue> SqlOrder = new List<ColumnValue>();
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
        public QuerySQL SetColumn(string name)
        {
            this.Column = name;
            return this;
        }
        public QuerySQL AddWhere(string column, object value)
        {
            this.SqlWhere.Add(new ColumnValue(column,value));
            return this;
        }
        public QuerySQL AddOrder(string column, EnumSort sort)
        {
            this.SqlOrder.Add(new ColumnValue(column, sort));
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
            if (SqlWhere.Count > 0) {
                int indexWhere = 0;
                sql.Append(" WHERE ");
                foreach (var item in SqlWhere) {
                    if (indexWhere > 0)
                        sql.Append(" AND ");

                    sql.AppendFormat(" `{0}` = @{0}{1} ", item.Column.Trim(), indexWhere);
                    parameter.Add(string.Format("@{0}{1}", item.Column.Trim(), indexWhere), item.Value);
                    indexWhere++;
                }
            }
            if (SqlOrder.Count > 0) {
                sql.Append(" ORDER BY ");
                bool first = true;
                foreach (var item in SqlOrder)
                {
                    if (item.Sort == EnumSort.None) continue;
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
                    sql.AppendFormat(" LIMIT {0},10", StartRow,StartRow+ PageSize);
                }
                else if(type==TypeSQL.SqlServer){
                    sql.AppendFormat(" offset {0} rows fetch next {1} rows only", StartRow, PageSize);
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
