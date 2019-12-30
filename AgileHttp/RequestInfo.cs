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
                var data = Setting.GetBodyData();
                WebRequest.ContentLength = data.Length;
                using (var requestStream = WebRequest.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
        }

        public async void AppendBodyAsync()
        {
            var body = Setting?.Body;
            if (body != null)
            {
                var data = Setting.GetBodyData();
                WebRequest.ContentLength = data.Length;
                using (var requestStream = await WebRequest.GetRequestStreamAsync())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
        }
    }
}
