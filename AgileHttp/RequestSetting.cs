using AgileHttp.serialize;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileHttp
{
    public class RequestSetting
    {
        private ISerializeProvider _serializeProvider;
        private Encoding _encoding;
        public RequestSetting(ISerializeProvider serializeProvider = null) 
        {
            _serializeProvider = serializeProvider;
        }
        public RequestSetting(Encoding encoding, ISerializeProvider serializeProvider)
        {
            _serializeProvider = serializeProvider;
            _encoding = encoding;
        }

        public ISerializeProvider SerializeProvider => _serializeProvider ?? AgileHttpRequest.DefaultSerializeProvider;
        public Encoding Encoding => _encoding ?? Encoding.UTF8;

        public object Body { get; set; }

        public virtual byte[] GetBodyData ()
        {
            if (Body == null)
            {
                throw new ArgumentNullException("Body");
            }

            if (Body is String)
            {
                return Encoding.GetBytes(Body as String);
            }

            var str = SerializeProvider.Serialize(Body);
            return Encoding.GetBytes(str);
        }

        public IDictionary<string, string> Headers { get; set; }

        public string ContentType { get; set; }

        public string Host { get; set; }

        public string Connection { get; set; }

        public string UserAgent { get; set; }

        public string Accept { get; set; }

        public string Referer { get; set; }
    }
}
