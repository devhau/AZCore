using AZCore.Database.Attributes;
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
                if (string.IsNullOrEmpty(field.Name) || string.IsNullOrWhiteSpace(field.Name))
                {
                    field.Name = p.Name;
                }
                if (field.FieldType == null)
                {
                    field.FieldType = TypeConvertor.ToSqlDbType(LookupDbType(p.PropertyType, "n/a", false, out ITypeHandler handler));
                }
                if (field.Length > 2000|| field.FieldType == System.Data.SqlDbType.VarChar && field.Length == 0) {
                    field.FieldType = System.Data.SqlDbType.Text;
                }

                return field;
            });
            this.FieldAutoIncrements = this.Fields.Where(p => p.IsAutoIncrement);
            this.FieldKeys = this.Fields.Where(p => p.IsKey);

        }

        private object GetValueByName(string name, IEntity model)
        {
            return this.typeEntity.GetProperty(name).GetValue(model);
        }
        private string GetLengthItem(FieldAttribute item)
        {

            if (item.Length == 0)
            {
                if (item.FieldType == System.Data.SqlDbType.VarChar)
                {
                    return "(1000)";
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
                Param = new DynamicParameters(),
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLInsert(IEntity model)
        {
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            StringBuilder SQLField = new StringBuilder();
            StringBuilder SQLValue = new StringBuilder();
            string prex = "";

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false))
            {
                SQLField.AppendFormat("{1}`{0}`", item.Name, prex);
                SQLValue.AppendFormat("{1}@{0}", item.Name, prex);
                parameter.Add("@" + item.Name, this.GetValueByName(item.Name, model));
                prex = ",";
            }
            SQL.AppendFormat("INSERT INTO `{0}` ({1}) VALUES({2});", this.TableName, SQLField.ToString(), SQLValue.ToString());
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLUpdate(IEntity model)
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("UPDATE `{0}` SET ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false && p.IsKey == false))
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.Name, prex);
                parameter.Add("@" + item.Name, this.GetValueByName(item.Name, model));
                prex = ",";
            }
            SQL.Append(" WHERE  ");
            prex = "";
            if (this.FieldKeys.Count() == 0)
            {
                foreach (var item in this.Fields.Where(p => p.IsAutoIncrement))
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.Name, prex);
                    parameter.Add("@" + item.Name, this.GetValueByName(item.Name, model));
                    prex = " AND ";
                }
            }
            else
            {
                foreach (var item in this.FieldKeys)
                {
                    SQL.AppendFormat("{1}`{0}`=@{0}", item.Name, prex);
                    parameter.Add("@" + item.Name, this.GetValueByName(item.Name, model));
                    prex = " AND ";
                }
            }

            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLDelete()
        {
            StringBuilder SQL = new StringBuilder();
            SQL.AppendFormat("DELETE FROM `{0}`  ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLDelete(IEntity model)
        {
            StringBuilder SQL = new StringBuilder();
            string prex = "";
            SQL.AppendFormat("DELETE FROM `{0}`  ", this.TableName);
            DynamicParameters parameter = new DynamicParameters();
            SQL.Append(" WHERE ");
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`=@{0}", item.Name, prex);
                parameter.Add("@" + item.Name, this.GetValueByName(item.Name, model));
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
                SQL.AppendFormat("`{0}` {1} {2} {3}  {4} {5},", item.Name, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "", item.IsKey ? " " : "  ", item.IsAutoIncrement ? "AUTO_INCREMENT" : "");
            }
            foreach (var item in this.FieldKeys.Where(p => p.IsAutoIncrement == false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3} ,", item.Name, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            foreach (var item in this.Fields.Where(p => p.IsAutoIncrement == false && p.IsKey == false))
            {
                SQL.AppendFormat("`{0}` {1} {2} {3}  ,", item.Name, item.FieldType, GetLengthItem(item), item.IsNull == false ? "NOT NULL" : "");
            }

            SQL.Append("PRIMARY KEY (");
            string prex = "";
            foreach (var item in this.FieldKeys)
            {
                SQL.AppendFormat("{1}`{0}`", item.Name, prex);
                prex = ",";
            }
            SQL.AppendFormat(" ))");
            return new SQLResult()
            {
                Param = new DynamicParameters(),
                SQL = SQL.ToString()
            };
        }
        #endregion


        #region AnalyticQuery

        #region Analytic
        private SQLResult AnalyticQuery(BinaryExpression be, ref int i, DynamicParameters param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new SQLResult();

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpressionression
            result.Param = param.IsNull() ? new DynamicParameters() : param;
            // Nếu biểu thức bên trái là MemberExpression
            if (be.Left.Is<MemberExpression>() || be.Left.Is<UnaryExpression>())
            {
                // Tên field
                string name = be.Left.Is<MemberExpression>() ? be.Left.As<MemberExpression>().Member.Name : be.Left.As<UnaryExpression>().Operand.As<MemberExpression>().Member.Name;

                // Nếu như bên phải là một biểu thức
                if (be.Right.Is<BinaryExpression>()) result.SQL = "{0}.{1} {3} {2}".Frmat(prefix, name, Analytic(be.Right.As<BinaryExpression>(), ref i, result.Param, prefix).SQL, be.NodeType.GetExpression());

                else
                {
                    // Giá trị
                    object value = be.Right.GetValue();

                    // Khởi tạo Param
                    result.Param.Add("{0}_{1}".Frmat(name, i),value);

                    // Tạo biểu thức cho mệnh đề where
                    result.SQL = "{3}.{0} {2} @{0}_{1}".Frmat(name, i, be.NodeType.GetExpression(), prefix);

                    // Tăng biến i
                    i++;
                }
            }
            else
            {
                // Biểu thức bên trái
                var rl = AnalyticQuery(be.Left.As<BinaryExpression>(), ref i, result.Param, prefix);

                // be.Left.As<UnaryExpression>().Operand is MemberExpression

                // Biểu thức bên phải
                var rr = AnalyticQuery(be.Right.As<BinaryExpression>(), ref i, result.Param, prefix);

                // Nối hai biểu thức với nhau
                result.SQL = "({0}) {2} ({1})".Frmat(rl.SQL, rr.SQL, be.NodeType.GetExpression());
            }

            // return kết quả
            return result;
        }
        private SQLResult AnalyticSet(BinaryExpression be, ref int i, DynamicParameters param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new SQLResult();

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpressionression
            result.Param = param.IsNull() ? new DynamicParameters() : param;

            // Nếu biểu thức bên trái là MemberExpression
            if (be.Left.Is<MemberExpression>()|| be.Left.Is<UnaryExpression>())
            {
                // Tên field
                string name = be.Left.Is<MemberExpression>()?be.Left.As<MemberExpression>().Member.Name: be.Left.As<UnaryExpression>().Operand.As<MemberExpression>().Member.Name;

                // Nếu right là một biểu thức thì phân tích
                if (be.Right.Is<BinaryExpression>()) result.SQL = "{0}.{1} = {2}".Frmat(prefix, name, Analytic(be.Right.As<BinaryExpression>(), ref i, result.Param, prefix).SQL);

                // Nếu là Constant
                else
                {
                    // Giá trị
                    object value = be.Right.GetValue();

                    // Khởi tạo Param
                    result.Param.Add("{0}_{1}".Frmat(name, i),value);

                    // Thiết lập biểu thức
                    result.SQL = "{2}.{0} = @{0}_{1}".Frmat(name, i, prefix);

                    // Tăng i
                    i++;
                }
            }
            else
            {
                // Biểu thức bên trái
                var rl = AnalyticSet(be.Left.As<BinaryExpression>(), ref i, result.Param, prefix);

                // Biểu thức bên phải
                var rr = AnalyticSet(be.Right.As<BinaryExpression>(), ref i, result.Param, prefix);

                // Ghép các mệnh đề
                result.SQL += "{0},{1},".Frmat(rl.SQL, rr.SQL);
            }

            // Trim dấu , cuối cùng
            result.SQL = result.SQL.TrimEnd(',');

            // return kết quả
            return result;
        }
        private SQLResult Analytic(BinaryExpression be, ref int i, DynamicParameters param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new SQLResult();

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpressionression
            result.Param = param.IsNull() ? new DynamicParameters() : param;

            // Biểu thức trái
            var rl = AnalyticExpression(be.Left, ref i, result.Param, prefix);

            // Biểu thức phải
            var rr = AnalyticExpression(be.Right, ref i, result.Param, prefix);

            // Ghép biểu thức trái và phải với nhau
            result.SQL = "({0} {2} {1})".Frmat(rl.SQL, rr.SQL, be.NodeType.GetExpression());

            // return kết quả
            return result;
        }
        private SQLResult AnalyticExpression(Expression ex, ref int i, DynamicParameters param = null, string prefix = "t")
        {
            // Biến lưu kết quả gồm Key = Mệnh đề Set, Value = Param
            var result = new SQLResult();

            // Khởi tạo biến lưu các Param nếu là lần đầu tiên phân tích BinaryExpression
            result.Param = param.IsNull() ? new DynamicParameters() : param;

            // Nếu là MemberExpression
            if (ex.Is<MemberExpression>())
            {
                // Gán thành MemberExpression
                var me = ex.As<MemberExpression>();

                // Nếu Base của me là một Constants thì tạo param
                if (me.Expression.Is<ConstantExpression>()) CreateParamFromExpression(me, result, ref i);

                // Ngược lại Format như một field của bảng
                else result.SQL = "{0}.{1}".Frmat(prefix, me.Member.Name);
            }
            // Nếu không thì lại phân tích cả biểu thức
            else if (ex.Is<BinaryExpression>()) result.SQL = Analytic(ex.As<BinaryExpression>(), ref i, result.Param, prefix).SQL;

            // Ngược lại thì coi như một biểu thức trả ra hằng số
            else CreateParamFromExpression(ex, result, ref i);

            // return kết quả
            return result;
        }
        private void CreateParamFromExpression(Expression ex, SQLResult result, ref int i)
        {
            result.Param.Add("azP{0}".Frmat(i), ex.GetValue());
            result.SQL = "@azP{0}".Frmat(i);
            i++;
        }
        #endregion

        public SQLResult SQLSelect<TModel>(Expression<Func<TModel, bool>> funcWhere)
        {
            // Biến lưu thứ tự các Param
            StringBuilder SQL = new StringBuilder();
            DynamicParameters parameter = new DynamicParameters();
            string prefix = "t";
            SQL.AppendFormat("SELECT * FROM `{0}`  {1}", this.TableName, prefix);
            int i = 0;
            if (funcWhere != null)
            {
                SQL.Append(" WHERE ");
                var where = AnalyticQuery(funcWhere.Body as BinaryExpression, ref i, parameter, prefix);
                SQL.Append(where.SQL);
            }
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
            string prefix = "t";
            SQL.AppendFormat("UPDATE `{0}` {1} SET ", this.TableName, prefix);
            int i = 0;
            if (updateSet!=null) {
                var azSet = AnalyticSet(updateSet.Body as BinaryExpression, ref i, parameter, prefix);
                SQL.Append(azSet.SQL);
            }
            if (funcWhere != null)
            {
                SQL.Append(" WHERE ");
                var where = AnalyticQuery(funcWhere.Body as BinaryExpression, ref i, parameter, prefix);
                SQL.Append(where.SQL);
               
            }
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        public SQLResult SQLDelete<TModel>(Expression<Func<TModel, bool>> funcWhere)
        {
            StringBuilder SQL = new StringBuilder();
            string prefix = "t";
            SQL.AppendFormat("DELETE  {1} FROM `{0}`  {1} ", this.TableName, prefix);
            DynamicParameters parameter = new DynamicParameters();
            int i = 0;
            if (funcWhere != null)
            {
                SQL.Append(" WHERE ");
                var where = AnalyticQuery(funcWhere.Body as BinaryExpression, ref i, parameter, prefix);
                SQL.Append(where.SQL);
            }
            return new SQLResult()
            {
                Param = parameter,
                SQL = SQL.ToString()
            };
        }
        #endregion
    }
}
