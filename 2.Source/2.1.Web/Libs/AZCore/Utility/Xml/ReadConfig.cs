using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;
using System;
namespace AZCore.Utility.Xml
{
    /// <summary>
    /// Đọc file Config và đưa dữ liệu đọc được vào một biến kiểu dữ liệu là T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ReadConfig<T> where T : ConfigBase, new()
    {
        /// <summary>
        /// Đối tượng để Serializer hoặc Deserializer đối tượng ra file hoặc ngược lại từ file ra đối tượng
        /// </summary>
        private static XmlSerializer xmlData = new XmlSerializer(typeof(T));

        /// <summary>
        /// Thực hiện đọc file setting và đưa thông tin vào đối tượng
        /// </summary>
        public static T Load(Action<T> action = null,Func<string,string> funcPath =null)
        {
            // Khởi tạo đối tượng T
            T t = new T(); if (action != null) action(t);

            // Lấy đường dẫn chưa file Settings
            var settingsPath =  t.GetPath();
            if (funcPath!=null) {

                settingsPath = funcPath(settingsPath);
            }

            // Nếu đường dẫn đến file setting không tồn tại thì trả ra đối tượng rỗng
                if (!File.Exists(settingsPath)) return t;

            // Đối tượng để đọc file Xml
            XmlTextReader xmlReader = null;
            try
            {
                // Khởi tạo đối tượng đọc file setting
                // Tham số của constructor là đường dẫn file cần độc
                xmlReader = new XmlTextReader(settingsPath);

                // Đọc file và Deserialize ra đối tượng
                t = (T)xmlData.Deserialize(xmlReader);
            }
            finally
            {                
                if (xmlReader != null) xmlReader.Close();
            }

            // return 
            return t;
        }

        public static void Save(T t)
        {
            // Lấy đường dẫn chưa file Settings
            var settingsPath = t.GetPath();

            // Nếu đường dẫn đến file setting không tồn tại thì trả ra đối tượng rỗng
            if (!File.Exists(settingsPath))
            {
                using (var fs = File.Create(settingsPath)) { }
            }

            // Đối tượng để ghi đối tượng xuống file xml
            XmlTextWriter xmlWriter = null;

            try
            {
                xmlWriter = new XmlTextWriter(settingsPath, Encoding.Unicode);
                xmlData.Serialize(xmlWriter, t);
            }
            finally
            {
                if (xmlWriter != null) xmlWriter.Close();
            }
        }
    }

    //[CacheFactory(TypeFactory = typeof(WebCacheFactory))]
    //public class CacheReadConfig<T> : CacheEntry<T> where T : ConfigBase, new()
    //{
    //    protected override T LoadForCache()
    //    {
    //        return ReadConfig<T>.Load();
    //    }

    //    public static T Load()
    //    {
    //        return new CacheReadConfig<T>().Get();
    //    }
    //}
}
