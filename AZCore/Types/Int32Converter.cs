using System.ComponentModel;
using System.Globalization;
using System;
using AZCore.Extensions;

namespace AZCore.Types
{
    [ConverterOf(Target = typeof(int))]
    public class Int32Converter : AZTypeConverter
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
                case AZTypeCode.String: return value.ToString().IsNull() ? 0 : Convert.ToInt32(value);

                case AZTypeCode.Int16:                
                case AZTypeCode.Byte:
                case AZTypeCode.Decimal:
                case AZTypeCode.Int64:
                case AZTypeCode.Double: return Convert.ToInt32(value);  
                
                case AZTypeCode.Int32: return value;
                case AZTypeCode.Boolean: return (bool)value == true ? 1 : 0;
                
                case AZTypeCode.DBNull: return 0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Có thể Convert được từ những kiểu dữ liệu gì
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.String | AZTypeCode.Double | AZTypeCode.Int32 | AZTypeCode.Int16 | AZTypeCode.Byte | AZTypeCode.Boolean | AZTypeCode.Int64 | AZTypeCode.DBNull;
        }
    }
}
