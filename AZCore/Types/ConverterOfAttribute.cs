using System;
namespace AZCore.Types
{
    /// <summary>
    /// Chỉ định class là Convert cho kiểu dữ liệu nào
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ConverterOfAttribute : Attribute
    {
        /// <summary>
        /// Target => Kiểu dữ liệu mong muốn được thực hiện Convert
        /// </summary>
        public Type Target { set; get; }
    }
}
