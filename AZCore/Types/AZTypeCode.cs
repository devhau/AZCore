using System;
using System.Collections.Generic;
using System.Text;

namespace AZCore.Types
{
    [Flags]
    public enum AZTypeCode
    {
        [AZTypeCodeOf(typeof(int))]
        Int32,

        [AZTypeCodeOf(typeof(long))]
        Int64,

        [AZTypeCodeOf(typeof(string))]
        String,

        [AZTypeCodeOf(typeof(decimal))]
        Decimal,

        [AZTypeCodeOf(typeof(bool))]
        Boolean,

        [AZTypeCodeOf(typeof(DateTime))]
        DateTime,

        [AZTypeCodeOf(typeof(TimeSpan))]
        TimeSpan,

        [AZTypeCodeOf(typeof(byte))]
        Byte,

        [AZTypeCodeOf(typeof(double))]
        Double,

        [AZTypeCodeOf(typeof(Guid))]
        Guid,

        [AZTypeCodeOf(typeof(short))]
        Int16,

        [AZTypeCodeOf(typeof(float))]
        Single,

        [AZTypeCodeOf(typeof(DBNull))]
        DBNull,

        UnKnown
    }
    /// <summary>
    /// Mở rộng phương thức cho AZTypeCode
    /// </summary>
    public static class AZTypeCodeExtender
    {
        /// <summary>
        /// Kiểm tra xem Type Code có hợp lệ, có nằm trong list Type Code cần check
        /// </summary>
        /// <param name="typeCode"></param>
        /// <param name="typeCodeChecking"></param>
        /// <returns></returns>
        public static bool IsSet(this AZTypeCode typeCode, AZTypeCode typeCodeChecking)
        {
            return (typeCode & typeCodeChecking) == typeCodeChecking;
        }
    }
}
