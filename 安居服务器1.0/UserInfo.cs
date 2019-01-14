using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace 安居服务器1._0
{
    [DataContract]
    public class UserInfo
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public int Age { get; set; }
        [DataMember(Order = 2)]
        public int Gender { get; set; }
        [DataMember(Order = 3)]
        public List<string> Lover { get; set; }

        public string LoversStr
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (Lover != null)
                {
                    foreach (string s in Lover)
                    {
                        sb.Append(s);
                        sb.Append(",");
                    }
                }
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
                return sb.ToString();
            }
        }
        [DataMember(Order = 4)]
        public ContactAddress Address { get; set; }
        [DataMember(Order = 5)]
        public Dictionary<string, string> DailyRecord
        {
            get;
            set;
        }
    }

    [DataContract]
    public class ContactAddress
    {
        [DataMember(Order = 0)]
        public string Province { get; set; }
        [DataMember(Order = 1)]
        public string City { get; set; }
        [DataMember(Order = 2)]
        public string Country { get; set; }
        [DataMember(Order = 3)]
        public string Details { get; set; }
    }
}

