using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace 安居服务器1._0
{
    public class JsonHelper
    {
        /// <summary>
        /// Json转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonText"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(string jsonText)
        {
            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText.Replace("\\'", @"\'")));
            T obj = (T)s.ReadObject(ms);
            ms.Dispose();
            return obj;
        }
        /// <summary>
        /// 对象转换成JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJSON<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            string result = string.Empty;
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                using (StreamReader read = new StreamReader(ms))
                {
                    result = read.ReadToEnd();
                }
            }
            return result;
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string NickName { get; set; }
            public Class Class { get; set; }
        }

        /// <summary>
        /// 学生班级实体
        /// </summary>
        public class Class
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
