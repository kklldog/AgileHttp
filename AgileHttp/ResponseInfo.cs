using AgileHttp.serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp
{
    public class ResponseInfo : IDisposable
    {
        public ResponseInfo(HttpWebResponse response, RequestInfo reqInfo , Exception ex = null)
        {
            this.Response = response;
            this.Exception = ex;
            RequestInfo = reqInfo;
        }
        public HttpStatusCode? StatusCode => Response?.StatusCode;
        public Exception Exception { get; private set; }
        public HttpWebResponse Response { get; private set; }
        public RequestInfo RequestInfo { get; private set; }

        private string _responseContent;

        /// <summary>
        /// Read response content, Not Thread safe .
        /// </summary>
        /// <returns></returns>
        public string GetResponseContent()
        {
            if (_responseContent != null)
            {
                return _responseContent;
            }

            if (Response == null)
            {
                return "";
            }

            if (_responseContent == null)
            {
                if (_responseContent == null)
                {
                    using (var responseStream = Response.GetResponseStream())
                    {
                        using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                            _responseContent = reader.ReadToEnd();
                    }
                }
            }

            return _responseContent;
        }

        /// <summary>
        /// Read response content async, Not Thread safe .
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetResponseContentAsync()
        {
            if (_responseContent != null)
            {
                return _responseContent;
            }

            if (Response == null)
            {
                return "";
            }

            using (var responseStream = Response.GetResponseStream())
            {
                using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    _responseContent = await reader.ReadToEndAsync();
            }

            return _responseContent;
        }

        public void Dispose()
        {
            if (Response != null)
            {
                Response.Dispose();
            }
        }
    }

}
