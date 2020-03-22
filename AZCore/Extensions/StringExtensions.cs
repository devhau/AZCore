using System.Text.RegularExpressions;

namespace AZCore.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperFirstChart(this string str) {
            if (str == null) return "";
            str = str.Trim();
            if (str.Length > 0) {

                return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
            }
            return "";
        }
        public static string Frmat(this string str,params object[] param) {
            return string.Format(str, param);
        }
        public static string GetOnlyDigital(this string str)
        {
            return Regex.Replace(str, @"[^\d]", string.Empty);
        }
    }
}
