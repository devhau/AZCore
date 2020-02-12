namespace AZCore.Utility.Xml
{
    /// <summary>
    /// Class Base để đọc file config do lập trình viên định nghĩa
    /// </summary>
    public abstract class ConfigBase
    {
        /// <summary>
        /// Lấy ra đường dẫn chưa file settings
        /// </summary>
        /// <returns></returns>
        public abstract string GetPath();   
    }
}
