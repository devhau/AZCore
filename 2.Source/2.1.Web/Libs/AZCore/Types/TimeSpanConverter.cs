using System;
using System.ComponentModel;
using System.Globalization;
using AZCore.Extensions;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(TimeSpan))]
    [ConverterOf(Target = typeof(TimeSpan?))]
    public class TimeSpanConverter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch(typeCode)
            {
                case AZTypeCode.DBNull: return null; 
                case AZTypeCode.TimeSpan: return value;
                case AZTypeCode.String: return value.IsNullOrEmpty() ? (TimeSpan?)null : TimeSpan.Parse(value.ToString());
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.TimeSpan | AZTypeCode.String | AZTypeCode.DBNull;
        }
    }
}
