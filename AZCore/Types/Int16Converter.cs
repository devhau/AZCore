using System.ComponentModel;
using System.Globalization;
using System;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(short))]
    public class Int16Converter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.String:
                case AZTypeCode.Byte: return Convert.ToInt16(value);
                case AZTypeCode.Int16: return value;
                case AZTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Có thể Convert được từ những TypeCode nào
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Int16 | AZTypeCode.String | AZTypeCode.Byte | AZTypeCode.DBNull;
        }
    }
}
