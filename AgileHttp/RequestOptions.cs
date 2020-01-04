using AgileHttp.serialize;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AgileHttp
{
    public class RequestOptions
    {
        private ISerializeProvider _serializeProvider;
        private Encoding _encoding;
        public RequestOptions(ISerializeProvider serializeProvider = null)
        {
            _serializeProvider = serializeProvider;
        }
        public RequestOptions(Encoding encoding, ISerializeProvider serializeProvider)
        {
            _serializeProvider = serializeProvider;
            _encoding = encoding;
        }

        public ISerializeProvider SerializeProvider => _serializeProvider ?? HTTP.DefaultSerializeProvider;
        public Encoding Encoding => _encoding ?? HTTP.DefaultEncoding;

        public IDictionary<string, string> Headers { get; set; }

        public string ContentType { get; set; }

        public string Host { get; set; }

        public string Connection { get; set; }

        public string UserAgent { get; set; }

        public string Accept { get; set; }

        public string Referer { get; set; }

        public X509Certificate Certificate { get; set; }

        public IWebProxy Proxy { get; set; }
    }
}
