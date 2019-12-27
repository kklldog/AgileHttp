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
        public static HttpWebRequest CreateRequest(string url, string method = "GET", RequestSetting setting = null)
        {
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
                    request.ContentType = setting.Connection;
                }
                if (!string.IsNullOrEmpty(setting.Host))
                {
                    request.ContentType = setting.Host;
                }
                if (!string.IsNullOrEmpty(setting.Accept))
                {
                    request.ContentType = setting.Accept;
                }
                if (!string.IsNullOrEmpty(setting.Referer))
                {
                    request.ContentType = setting.Referer;
                }
                if (!string.IsNullOrEmpty(setting.UserAgent))
                {
                    request.ContentType = setting.UserAgent;
                }

                if (setting.Headers != null)
                {
                    foreach (var keyValuePair in setting.Headers)
                    {
                        request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                }
            }

            return request;
        }

        public static RequestResult DoRequest(string url, string method = "GET", RequestSetting setting = null)
        {
            var request = CreateRequest(url, method, setting);

            try
            {
                if (setting?.Body != null)
                {
                    request.ContentLength = setting.Body.Length;
                    using (var requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(setting.Body, 0, setting.Body.Length);
                    }
                }
                else
                {
                    request.ContentLength = 0;
                }

                var response = request.GetResponse() as HttpWebResponse;

                return new RequestResult(response);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                return new RequestResult(response, ex);
            }
            catch (Exception ex)
            {
                return new RequestResult(null, ex);
            }

        }

        public static Task<RequestResult> DoRequestAsync(string url, string method = "GET", RequestSetting setting = null)
        {
            var task = Task.Run(async () =>
            {
                var request = CreateRequest(url, method, setting);
                try
                {
                    if (setting?.Body != null)
                    {
                        request.ContentLength = setting.Body.Length;
                        using (var requestStream = await request.GetRequestStreamAsync())
                        {
                            requestStream.Write(setting.Body, 0, setting.Body.Length);
                        }
                    }
                    var response = await request.GetResponseAsync() as HttpWebResponse;
                    return new RequestResult(response);
                }
                catch (WebException ex)
                {
                    var response = ex.Response as HttpWebResponse;
                    return new RequestResult(response, ex);
                }
                catch (Exception ex)
                {
                    return new RequestResult(null, ex);
                }
            });

            return task;

        }

    }
}
