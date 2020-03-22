using System.ComponentModel;
using System.Globalization;
using System;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(double))]
    public class DoubleConverter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.String:
                case AZTypeCode.Single: return Convert.ToDouble(value);                   
                case AZTypeCode.Double: return value;
                case AZTypeCode.DBNull: return 0;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Các type code có thể thực hiện convert được
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Double | AZTypeCode.String | AZTypeCode.DBNull;
        }
    }
}
