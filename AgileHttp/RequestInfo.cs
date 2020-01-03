using AgileHttp.serialize;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp
{
    public class RequestInfo
    {
        public RequestInfo(HttpWebRequest request, object body = null, RequestOptions options = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            WebRequest = request;
            Options = options;
            Body = body;
        }

        public RequestInfo Config(RequestOptions options)
        {
            Options = options;
            if (Options != null)
            {
                if (!string.IsNullOrEmpty(Options.ContentType))
                {
                    WebRequest.ContentType = Options.ContentType;
                }
                if (!string.IsNullOrEmpty(Options.Connection))
                {
                    WebRequest.Connection = Options.Connection;
                }
                if (!string.IsNullOrEmpty(Options.Host))
                {
                    WebRequest.Host = Options.Host;
                }
                if (!string.IsNullOrEmpty(Options.Accept))
                {
                    WebRequest.Accept = Options.Accept;
                }
                if (!string.IsNullOrEmpty(Options.Referer))
                {
                    WebRequest.Referer = Options.Referer;
                }
                if (!string.IsNullOrEmpty(Options.UserAgent))
                {
                    WebRequest.UserAgent = Options.UserAgent;
                }

                if (Options.Headers != null)
                {
                    foreach (var keyValuePair in Options.Headers)
                    {
                        WebRequest.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                }
            }
            return this;
        }

        public HttpWebRequest WebRequest { get; private set; }

        public RequestOptions Options { get; private set; }

        public Object Body { get; private set; }

        internal void AppendBody()
        {
            if (Body != null)
            {
                var data = GetBodyData();
                WebRequest.ContentLength = data.Length;
                using (var requestStream = WebRequest.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
        }

        internal async Task AppendBodyAsync()
        {
            if (Body != null)
            {
                var data = GetBodyData();
                WebRequest.ContentLength = data.Length;
                using (var requestStream = await WebRequest.GetRequestStreamAsync())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
        }

        private Encoding GetEncoding()
        {
            if (Options != null)
            {
                return Options.Encoding;
            }

            return HTTP.DefaultEncoding;
        }

        private ISerializeProvider GetSerializeProvider()
        {
            if (Options != null)
            {
                return Options.SerializeProvider;
            }

            return HTTP.DefaultSerializeProvider;
        }

        public virtual byte[] GetBodyData()
        {
            if (Body == null)
            {
                throw new ArgumentNullException("Body");
            }

            if (Body is byte[])
            {
                return Body as byte[];
            }

            if (Body is String)
            {
                return GetEncoding().GetBytes(Body as String);
            }

            var str = GetSerializeProvider().Serialize(Body);
            return GetEncoding().GetBytes(str);
        }
    }
}
