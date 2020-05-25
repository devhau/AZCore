using System;
using System.ComponentModel;
using System.Globalization;
using AZCore.Extensions;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(DateTime))]
    [ConverterOf(Target = typeof(DateTime?))]
    public class DateTimeConverter : AZTypeConverter
    {
        /// <summary>
        /// Thực hiện Convert
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <param name="typeCode"></param>
        /// <returns></returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.String: return value.ToString().Trim().IsNullOrEmpty() ? (DateTime?)null : Convert.ToDateTime(value, CultureInfo.GetCultureInfo("vi-VN"));
                case AZTypeCode.DateTime: return value;                
                case AZTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Các type code có thể Convert được
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.DateTime | AZTypeCode.String | AZTypeCode.DBNull;
        }
    }
}
