using System.ComponentModel;
using System.Globalization;
using System;
using AZCore.Extensions;

namespace AZCore.Types
{
    [ConverterOf(Target = typeof(decimal))]
    [ConverterOf(Target = typeof(decimal?))]
    public class DecimalConverter : AZTypeConverter
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
                case AZTypeCode.String:
                    var strValue = value.ToString().GetOnlyDigital();
                    return strValue.IsNull() ? (decimal?)null : Convert.ToDecimal(strValue); // hanhth
                //case AZTypeCode.String: return value.ToString().Trim().IsNull() ? (decimal?)null : Convert.ToDecimal(value.ToString().Replace(",",""), CultureInfo.GetCultureInfo("vi-VN"));//sonpc
                case AZTypeCode.Int64:
                case AZTypeCode.Int32:
                case AZTypeCode.Int16:
                case AZTypeCode.Double: return Convert.ToDecimal(value);
                case AZTypeCode.Decimal: return value;
                // case AZTypeCode.DBNull: return new Decimal(0);
                case AZTypeCode.DBNull: return null;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Các kiểu dữ liệu có thể Convert được
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Decimal | AZTypeCode.String | AZTypeCode.Int64 | AZTypeCode.Int32 | AZTypeCode.Int16 | AZTypeCode.Double | AZTypeCode.DBNull;
        }
    }
}
