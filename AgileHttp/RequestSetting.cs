using System;
using System.Collections.Generic;
using System.Text;

namespace AgileHttp
{
    public class RequestSetting
    {
        public byte[] Body { get; set; }

        public List<KeyValuePair<string, string>> Headers { get; set; }

        public string ContentType { get; set; }

        public string Host { get; set; }

        public string Connection { get; set; }

        public string UserAgent { get; set; }

        public string Accept { get; set; }

        public string Referer { get; set; }


    }
}
