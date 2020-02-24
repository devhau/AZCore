using AZCore.Database.Attr;
using AZCore.Extensions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static Dapper.SqlMapper;

namespace AZCore.Database.SQL
{
    internal class EntitySQL
    {
        [Obsolete]
        public static EntitySQL NewSQL(EntityBase entity) {
            return new EntitySQL(entity);
        }

        private IEnumerable<FieldAttribute> Fields { get; set; }
        private IEnumerable<FieldAttribute> FieldKeys { get; set; }
        private IEnumerable<FieldAttribute> FieldAutoIncrements { get; set; }
        private string TableName { get; set; }
        EntityBase entity;

        [Obsolete]
        public EntitySQL(EntityBase entity)
        {
            this.entity = entity;
          this.TableName=  this.entity.GetType().GetAttribute<TableInfoAttribute>().TableName;
            this.Fields = this.entity.GetType().GetProperties().Where((p) => p.GetAttribute<FieldAttribute>() != null).Select((p) =>
            {
                var field = p.GetAttribute<FieldAttribute>();
                if (string.IsNullOrEmpty(field.FieldName) || string.IsNullOrWhiteSpace(field.FieldName))
                {
                    field.FieldName = p.Name;
                }
                if (field.FieldType==null)
                {
                    field.FieldType = TypeConvertor.ToSqlDbType(SqlMapper.LookupDbType(p.PropertyType, "n/a", false, out ITypeHandler handler));
                }
                
                field.FieldName = field.FieldName;
                
                return field;
            });
            this.FieldAutoIncrements = this.Fields.Where(p => p.IsAutoIncrement);
            this.FieldKeys = this.Fields.Where(p => p.IsKey);
            
        }
        private object GetValueByName(string name) {
            return this.entity.GetType().GetProperty(name).GetValue(this.entity);
        
        }
        public SQLResult CreateTableIfNotExit() {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}` (", this.TableName);
            foreach (var item in this.FieldAutoIncrements) {
                SQL.AppendFormat("`{0}` {1} {2} {3}  {4} {5},", item.FieldName,item.FieldType, GetLengthItem(item), item.IsNull==false? "NOT NULL" : "",item.IsKey? " " : "  ", item.IsAutoIncrement? "AUTO_INCREMENT" : "");
            }
            foreach (var item in this.FieldKeys.Where(p=>p.IsAutoIncrement==false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3} ,", item.FieldName, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false&&p.IsKey==false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3}  ,", item.FieldName, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            SQL.Append("PRIMARY KEY (");
            string prex = "";
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("`{0}`{1}", item.FieldName, prex);
                prex = ",";
            }
            SQL.AppendFormat(" ))");
            return new SQLResult() { 
            
                SQL= SQL.ToString()
            };
        }
        private string GetLengthItem(FieldAttribute item) {

            if (item.Length == 0)
            {
                if (item.FieldType == System.Data.SqlDbType.VarChar)
                {
                    return "(10000)";
                }
                else if (item.FieldType == System.Data.SqlDbType.Char)
                    return "(255)";
            }
            if (item.Length != 0) {

                return "(" + item.Length + ")";
            }
            return "";

        }
        public SQLResult ToSqlSelect()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat("SELECT FROM `{0}`  ", this.TableName);
            return new SQLResult()
            {

                SQL = SQL.ToString()
            };
        }
        public SQLResult ToSqlInsert()
        {
            StringBuilder SQL = new StringBuilder();
            StringBuilder SQLField = new StringBuilder();
            StringBuilder SQLValue = new StringBuilder();
            string prex = "";
            DynamicParameters parameter = new DynamicParameters();

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false)) {
                SQLField.AppendFormat("{1}`{0}`", item.FieldName, prex);
                SQLValue.AppendFormat("{1}@{0}", item.FieldName,prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                prex = ",";
            }
            SQL.AppendFormat("INSERT INTO `{0}` ({1}) VALUES({2});",this.TableName,SQLField.ToString(),SQLValue.ToString());
            return new SQLResult()
            {
                Param=parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult ToSqlUpdate<TEntity>(Expression<Func<TEntity, bool>> updateSet, Expression<Func<TEntity, bool>> funcWhere)
        {
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
            public SQLResult ToSqlUpdate()
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("UPDATE `{0}` SET ",this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false&&p.IsKey==false))
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                prex = ",";
            }
            SQL.Append(" WHERE  ");
            prex = "";
            if (this.FieldKeys.Count() == 0)
            {
                foreach (var item in this.Fields.Where(p=>p.IsAutoIncrement))
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                    parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                    prex = " AND ";
                }
            }
            else {
                foreach (var item in this.FieldKeys)
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                    parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                    prex = " AND ";
                }
            }
            
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult ToSqlDelete()
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("DELETE FROM `{0}`  ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            SQL.AppendFormat("WHERE  `{0}` SET ", this.TableName);
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                prex = " AND ";
            }
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult ToSqlDelete<TEntity>(Expression<Func<TEntity, bool>> funcWhere)
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("DELETE FROM `{0}`  ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            SQL.AppendFormat("WHERE  `{0}` SET ", this.TableName);
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName));
                prex = " AND ";
            }
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult ToSqlSave()
        {
            StringBuilder SQL = new StringBuilder();
            return null;
        }
        public void AnalyticQuery(BinaryExpression be, ref int i, DynamicParameters parameter, string prefix = "t") {


        }
        public void AnalyticSet(BinaryExpression be, ref int i, DynamicParameters parameter, string prefix = "t")
        {


        }
        


    }
}
