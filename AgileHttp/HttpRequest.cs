using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp
{

    public class HttpRequest
    {
        public static RequestInfo CreateRequest(string url, string method = "GET", RequestSetting setting = null)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }
            if (string.IsNullOrEmpty(method))
            {
                throw new ArgumentNullException(nameof(method));
            }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method;

            if (setting != null)
            {
                if (!string.IsNullOrEmpty(setting.ContentType))
                {
                    request.ContentType = setting.ContentType;
                }
                if (!string.IsNullOrEmpty(setting.Connection))
                {
                    request.Connection = setting.Connection;
                }
                if (!string.IsNullOrEmpty(setting.Host))
                {
                    request.Host = setting.Host;
                }
                if (!string.IsNullOrEmpty(setting.Accept))
                {
                    request.Accept = setting.Accept;
                }
                if (!string.IsNullOrEmpty(setting.Referer))
                {
                    request.Referer = setting.Referer;
                }
                if (!string.IsNullOrEmpty(setting.UserAgent))
                {
                    request.UserAgent = setting.UserAgent;
                }

                if (setting.Headers != null)
                {
                    foreach (var keyValuePair in setting.Headers)
                    {
                        request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                }
            }

            return new RequestInfo (request,setting);
        }

        public static ResponseResult Send(RequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException(nameof(requestInfo));
            }

            try
            {
                requestInfo.AppendBody();
                var response = requestInfo.WebRequest.GetResponse() as HttpWebResponse;
                return new ResponseResult(response);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                return new ResponseResult(response, ex);
            }
            catch (Exception ex)
            {
                return new ResponseResult(null, ex);
            }
        }

        public async static Task<ResponseResult> SendAsync(RequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException(nameof(requestInfo));
            }

            try
            {
                requestInfo.AppendBodyAsync();
                var response = await requestInfo.WebRequest.GetResponseAsync() as HttpWebResponse;
                return new ResponseResult(response);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                return new ResponseResult(response, ex);
            }
            catch (Exception ex)
            {
                return new ResponseResult(null, ex);
            }
        }

        public static ResponseResult Send(string url, string method = "GET", RequestSetting setting = null)
        {
            var requestInfo = CreateRequest(url, method, setting);
            return Send(requestInfo);
        }

        public async static Task<ResponseResult> SendAsync(string url, string method = "GET", RequestSetting setting = null)
        {
            var requestInfo = CreateRequest(url, method, setting);
            var result = await SendAsync(requestInfo);

            return result;
        }

    }
}
