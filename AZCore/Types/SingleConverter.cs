using System.ComponentModel;
using System.Globalization;
using System;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(float))]
    public class SingleConverter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.String: return value == null || string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToSingle(value);
                case AZTypeCode.Double: return Convert.ToSingle(value);                
                case AZTypeCode.Single: return value;
                case AZTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Single | AZTypeCode.String | AZTypeCode.Double | AZTypeCode.DBNull;
        }
    }
}
