using System.ComponentModel;
using System.Globalization;
using System;
namespace AZCore.Types
{
    [ConverterOf(Target = typeof(string))]
    public class StringConverter : AZTypeConverter
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
                case AZTypeCode.DBNull: return string.Empty;
                default: return value.ToString();
            }
        }

        /// <summary>
        /// Các kiểu dữ liệu có thể Convert được
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.UnKnown;
        }

        /// <summary>
        /// Có thể  Convert được từ Type nào
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
    }
}
