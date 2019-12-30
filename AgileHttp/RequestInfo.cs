using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AgileHttp
{
    public class RequestInfo
    {
        public RequestInfo(HttpWebRequest request, RequestSetting setting = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            WebRequest = request;
            Setting = setting;
        }
        public HttpWebRequest WebRequest { get; private set; }

        public RequestSetting Setting { get; private set; }

        public void AppendBody()
        {
            var body = Setting?.Body;
            if (body != null)
            {
                WebRequest.ContentLength = body.Length;
                using (var requestStream = WebRequest.GetRequestStream())
                {
                    requestStream.Write(body, 0, body.Length);
                }
            }
        }

        public async void AppendBodyAsync()
        {
            var body = Setting?.Body;
            if (body != null)
            {
                WebRequest.ContentLength = body.Length;
                using (var requestStream = await WebRequest.GetRequestStreamAsync())
                {
                    requestStream.Write(body, 0, body.Length);
                }
            }
        }
    }
}
