using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace AZCore.Extensions
{
    /// <summary>
    /// Phương thức mở rộng cho MemberExpression
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Lấy giá trị của MemberExpression
        /// </summary>
        /// <param name="me"></param>
        /// <returns></returns>
        public static object GetValue(this Expression me)
        {
            // Convert ra object
            var objectMember = Expression.Convert(me, typeof(object));
            // Lấy giá trị của me
            return Expression.Lambda<Func<object>>(objectMember).Compile()();
        }

        /// <summary>
        /// Lấy ra tên thuộc tính nếu sử dụng lamda
        /// a=> a.Name 
        /// </summary>
        /// <param name="propertyLamda"></param>
        /// <returns></returns>
        public static string GetName(this LambdaExpression propertyLamda)
        {
            var me = propertyLamda.GetMemberInfo();
            return me.IsNull() ? string.Empty : me.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyLamda"></param>
        /// <returns></returns>
        public static MemberInfo GetMemberInfo(this LambdaExpression propertyLamda)
        {
            var me = propertyLamda.Body is MemberExpression ? propertyLamda.Body as MemberExpression : (propertyLamda.Body as UnaryExpression).Operand as MemberExpression;
            return me.IsNull() ? null : me.Member;
        }

        /// <summary>
        /// Lấy ra danh sách dữ liệu dạng Key Value từ một biểu thức dạng phương thức
        /// </summary>
        /// <param name="propertyLamda"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetValues(this LambdaExpression propertyLamda)
        {
            // Tạo dic lưu trữ kết quả trả ra
            var dic = new Dictionary<string, object>();

            // Nếu Null và không phải MethodCallExpression
            if (propertyLamda.IsNull() || !(propertyLamda.Body is MethodCallExpression)) return dic;

            // Mảng Expression tham số 
            var arg = (propertyLamda.Body as MethodCallExpression).Arguments[0] as NewArrayExpression;

            // Duyệt qua từng Expression tham số để lọc lấy thông tin Field và Value
            for (int i = 0; i < arg.Expressions.Count; i++)
            {
                // Lấy ra MemberExpression
                var me = arg.Expressions[i] is MemberExpression ? arg.Expressions[i] as MemberExpression : (arg.Expressions[i] as UnaryExpression).Operand as MemberExpression;

                // Nếu không có MemberExpression thì tiếp tục
                if (me.IsNull()) continue;

                // Lấy giá trị cho Param
                dic[me.Member.Name] = me.GetValue();
            }

            // return
            return dic;
        }
    }

    /// <summary>
    /// Mở rộng cho ExpressionType
    /// </summary>
    public static class ExpressionTypeExtender
    {
        /// <summary>
        /// Convert ExpressionType thành ExpressionType của Sql
        /// </summary>
        /// <param name="et"></param>
        /// <returns></returns>
        public static string GetExpression(this ExpressionType et)
        {
            switch (et)
            {
                case ExpressionType.Equal: return "=";
                case ExpressionType.GreaterThan: return ">";
                case ExpressionType.GreaterThanOrEqual: return ">=";
                case ExpressionType.LessThan: return "<";
                case ExpressionType.LessThanOrEqual: return "<=";
                case ExpressionType.NotEqual: return "<>";
                case ExpressionType.AndAlso: return "AND";
                case ExpressionType.OrElse: return "OR";
                case ExpressionType.Add: return "+";
                case ExpressionType.Subtract: return "-";
                case ExpressionType.Divide: return "/";
                case ExpressionType.Power: return "*";
            }

            return string.Empty;
        }
    }

    /// <summary>
    /// Thêm các phương thức cho MethodCallExpression
    /// </summary>
    public static class MethodCallExpressionExtender
    {
        /// <summary>
        /// Lấy mảng giá trị của tham số truyền vào
        /// </summary>
        /// <param name="mce"></param>
        /// <returns></returns>
        public static object[] GetValueOfParameter(this MethodCallExpression mce)
        {
            return mce.Arguments.Select(c => Expression.Lambda(c is UnaryExpression ? ((UnaryExpression)c).Operand : c).Compile().DynamicInvoke()).ToArray();
        }
    }
}
