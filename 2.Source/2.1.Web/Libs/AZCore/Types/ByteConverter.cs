using System.ComponentModel;
using System.Globalization;
using System;
using AZCore.Extensions;

namespace AZCore.Types
{
    [ConverterOf(Target = typeof(byte))]
    public class ByteConverter : AZTypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value, AZTypeCode typeCode)
        {
            switch (typeCode)
            {
                case AZTypeCode.Int32:
                case AZTypeCode.String: return value.IsNullOrEmpty() ? (byte?)null : Convert.ToByte(value.ToString().GetOnlyDigitalAndDot());                 
                case AZTypeCode.Byte: return value;
                case AZTypeCode.DBNull: return 0;
            }

            return base.ConvertFrom(context, culture, value, typeCode);
        }

        /// <summary>
        /// Các kiểu dữ liệu có thể Convert sang byte
        /// </summary>
        /// <returns></returns>
        public override AZTypeCode GetTypeCodeCanConvert()
        {
            return AZTypeCode.Byte | AZTypeCode.String | AZTypeCode.Int32 | AZTypeCode.DBNull;
        }
    }
}
