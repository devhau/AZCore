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
    public sealed class BuildSQL
    {
        public static BuildSQL NewSQL(Type typeEntity)
        {
            return new BuildSQL(typeEntity);
        }
        #region Basic 
        public IEnumerable<FieldAttribute> Fields { get; private set; }
        public IEnumerable<FieldAttribute> FieldKeys { get; private set; }
        public IEnumerable<FieldAttribute> FieldAutoIncrements { get; private set; }
        public string TableName { get; private set; }
        private Type typeEntity=null;
        private BuildSQL(Type _typeEntity)
        {
            this.typeEntity = _typeEntity;
            this.TableName = this.typeEntity.GetAttribute<TableInfoAttribute>().TableName;
            this.Fields = this.typeEntity.GetProperties().Where((p) => p.GetAttribute<FieldAttribute>() != null).Select((p) =>
            {
                var field = p.GetAttribute<FieldAttribute>();
                if (string.IsNullOrEmpty(field.FieldName) || string.IsNullOrWhiteSpace(field.FieldName))
                {
                    field.FieldName = p.Name;
                }
                if (field.FieldType == null)
                {
                    field.FieldType = TypeConvertor.ToSqlDbType(LookupDbType(p.PropertyType, "n/a", false, out ITypeHandler handler));
                }

                field.FieldName = field.FieldName;

                return field;
            });
            this.FieldAutoIncrements = this.Fields.Where(p => p.IsAutoIncrement);
            this.FieldKeys = this.Fields.Where(p => p.IsKey);

        }

        private object GetValueByName(string name, IEntityModel model)
        {
            return this.typeEntity.GetProperty(name).GetValue(model);
        }
        private string GetLengthItem(FieldAttribute item)
        {

            if (item.Length == 0)
            {
                if (item.FieldType == System.Data.SqlDbType.VarChar)
                {
                    return "(10000)";
                }
                else if (item.FieldType == System.Data.SqlDbType.Char)
                    return "(255)";
            }
            if (item.Length != 0)
            {

                return "(" + item.Length + ")";
            }
            return "";

        }
        public SQLResult SQLSelect()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat("SELECT * FROM `{0}`  ", this.TableName);
            return new SQLResult()
            {

                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLInsert(IEntityModel model)
        {
            StringBuilder SQL = new StringBuilder();
            StringBuilder SQLField = new StringBuilder();
            StringBuilder SQLValue = new StringBuilder();
            string prex = "";
            DynamicParameters parameter = new DynamicParameters();

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false))
            {
                SQLField.AppendFormat("{1}`{0}`", item.FieldName, prex);
                SQLValue.AppendFormat("{1}@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName, model));
                prex = ",";
            }
            SQL.AppendFormat("INSERT INTO `{0}` ({1}) VALUES({2});", this.TableName, SQLField.ToString(), SQLValue.ToString());
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLUpdate(IEntityModel model)
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("UPDATE `{0}` SET ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false && p.IsKey == false))
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName, model));
                prex = ",";
            }
            SQL.Append(" WHERE  ");
            prex = "";
            if (this.FieldKeys.Count() == 0)
            {
                foreach (var item in this.Fields.Where(p => p.IsAutoIncrement))
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                    parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName, model));
                    prex = " AND ";
                }
            }
            else
            {
                foreach (var item in this.FieldKeys)
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                    parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName, model));
                    prex = " AND ";
                }
            }

            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLDelete(IEntityModel model)
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("DELETE FROM `{0}`  ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            SQL.AppendFormat("WHERE  `{0}` SET ", this.TableName);
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.FieldName, prex);
                parameter.Add("@" + item.FieldName, this.GetValueByName(item.FieldName, model));
                prex = " AND ";
            }
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult CreateTableIfNotExit()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat("CREATE TABLE IF NOT EXISTS `{0}` (", this.TableName);
            foreach (var item in this.FieldAutoIncrements)
            {
                SQL.AppendFormat("`{0}` {1} {2} {3}  {4} {5},", item.FieldName, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "", item.IsKey ? " " : "  ", item.IsAutoIncrement ? "AUTO_INCREMENT" : "");
            }
            foreach (var item in this.FieldKeys.Where(p => p.IsAutoIncrement == false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3} ,", item.FieldName, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false && p.IsKey == false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3}  ,", item.FieldName, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            SQL.Append("PRIMARY KEY (");
            string prex = "";
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`", item.FieldName, prex);
                prex = ",";
            }
            SQL.AppendFormat(" ))");
            return new SQLResult()
            {

                SQL = SQL.ToString()
            };
        }
        #endregion


        #region AnalyticQuery
        public SQLResult AnalyticSet(BinaryExpression be, ref int index, DynamicParameters param =null)
        {

            var result = new SQLResult()
            {
                SQL = string.Empty
            };
            result.Param = param == null ? new DynamicParameters() : param;

            return result;
        }
        public SQLResult AnalyticQuery(BinaryExpression be, ref int index, DynamicParameters param = null,string prefix="t") 
        {
            var result = new SQLResult()
            {
                SQL = string.Empty
            };
            result.Param = param == null ? new DynamicParameters() : param;


            return result;
        }
        public SQLResult SQLSelect<TModel>(Expression<Func<TModel, bool>> funcWhere)
        {
            // Biến lưu thứ tự các Param
            int i = 0;
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
           
            var where = AnalyticQuery(funcWhere.Body as BinaryExpression, ref i);
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLUpdate<TModel>(Expression<Func<TModel, bool>> updateSet, Expression<Func<TModel, bool>> funcWhere)
        {
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLDelete<TModel>(Expression<Func<TModel, bool>> funcWhere)
        {
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        #endregion
    }
}
