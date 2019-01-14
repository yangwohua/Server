using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 安居服务器1._0
{
    class TcpSocket
    {

        Socket socket_1;

        #region 返回Socket对象
        public Socket socket()
        {
            socket_1= new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            return socket_1;
        }

        #endregion

        public void close_socket()
        {
            socket_1.Close();
        }

        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }

        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string NickName { get; set; }
            public Class Class { get; set; }
        }
        public class Class
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }


    }
}
