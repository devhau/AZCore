using System.ComponentModel;
using System.Globalization;
namespace AZCore.Types
{
    /// <summary>
    /// Convert dữ liệu sang kiểu bool
    /// </summary>
    [ConverterOf(Target = typeof(bool))]
    public class BooleanConverter : AZTypeConverter
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
                case AZTypeCode.String: return value.ToString().ToLower() == "true" || value.ToString() == "1";
                case AZTypeCode.Int32: return value.ToString() == "1";
                case AZTypeCode.Boolean: return value;
                case AZTypeCode.DBNull: return false;
            }

            // Base
            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Các kiểu dữ liệu có thể Convert được
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Int32 | AZTypeCode.Boolean | AZTypeCode.String | AZTypeCode.DBNull;
        }
    }
}
