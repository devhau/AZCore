using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Extensions
{
    public static class StringExtensions
    {
        public static string ToUpperFirstChart(this string str) {
            if (str == null) return "";
            str = str.Trim();
            if (str.Length > 0) {

                return str[0].ToString().ToUpper() + str.Substring(1);
            }
            return "";
        }
    }
}
