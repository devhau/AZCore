using System;
using System.ComponentModel;
using System.Globalization;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(Guid))]
    public class GuidConverter : AZTypeConverter
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
                case AZTypeCode.String: return new Guid(value.ToString());
                case AZTypeCode.Guid: return value;
                case AZTypeCode.DBNull: return Guid.Empty;
            }
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Có thể convert được từ những type nào
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.String | AZTypeCode.Guid | AZTypeCode.DBNull;
        }
    }
}
