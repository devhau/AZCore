using System.ComponentModel;
using System.Globalization;
using System;
using AZCore.Extensions;

namespace AZCore.Types
{
    [ConverterOf(Target = typeof(long))]
    public class Int64Converter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.String:
                    return value.IsNullOrEmpty() ? (long?)null : Convert.ToInt64(value.ToString().GetOnlyDigitalAndDot());
                case AZTypeCode.Int16:                
                case AZTypeCode.Int32:                
                case AZTypeCode.Decimal:
                case AZTypeCode.Byte: return "".Equals(value)?0:Convert.ToInt64(value);                
                case AZTypeCode.Int64: return value;
                case AZTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Int64 | AZTypeCode.String | AZTypeCode.Int16 | AZTypeCode.Int32 | AZTypeCode.Byte | AZTypeCode.Decimal | AZTypeCode.DBNull;
        }
    }
}
