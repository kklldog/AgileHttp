using AgileHttp.serialize;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp
{
    public class HTTP
    {
        static HTTP() {
            _defaultSerializeProvider = new JsonSerializeProvider();
            _defaultEncoding = Encoding.UTF8;
        }

        private static ISerializeProvider _defaultSerializeProvider;
        private static Encoding _defaultEncoding;

        /// <summary>
        /// Default SerializeProvider , JsonSerializeProvider is default .
        /// </summary>
        public static ISerializeProvider DefaultSerializeProvider => _defaultSerializeProvider;
        /// <summary>
        /// Default Encoding , UTF8 Encoding is default .
        /// </summary>
        public static Encoding DefaultEncoding => _defaultEncoding;
        public static void SetDefaultSerializeProvider(ISerializeProvider provider) 
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _defaultSerializeProvider = provider;
        }
        public static void SetDefaultEncoding(Encoding encoding) {
            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            _defaultEncoding = encoding;
        }

        public static RequestInfo CreateRequest(string url, string method = "GET",object body = null)
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

            return new RequestInfo (request, body);
        }

        public static ResponseInfo Send(RequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException(nameof(requestInfo));
            }

            try
            {
                requestInfo.AppendBody();
                var response = requestInfo.WebRequest.GetResponse() as HttpWebResponse;
                return new ResponseInfo(response, requestInfo);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                return new ResponseInfo(response, requestInfo, ex);
            }
            catch (Exception ex)
            {
                return new ResponseInfo(null, requestInfo, ex);
            }
        }

        public async static Task<ResponseInfo> SendAsync(RequestInfo requestInfo)
        {
            if (requestInfo == null)
            {
                throw new ArgumentNullException(nameof(requestInfo));
            }

            try
            {
                await requestInfo.AppendBodyAsync();
                var response = await requestInfo.WebRequest.GetResponseAsync() as HttpWebResponse;
                return new ResponseInfo(response, requestInfo);
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                return new ResponseInfo(response, requestInfo, ex);
            }
            catch (Exception ex)
            {
                return new ResponseInfo(null, requestInfo, ex);
            }
        }

        public static ResponseInfo Send(string url, string method = "GET", Object body = null, RequestOptions setting = null)
        {
            var requestInfo = CreateRequest(url, method, body).Config(setting);
            return Send(requestInfo);
        }

        public async static Task<ResponseInfo> SendAsync(string url, string method = "GET", Object body = null, RequestOptions setting = null)
        {
            var requestInfo = CreateRequest(url, method, body).Config(setting);
            var result = await SendAsync(requestInfo);

            return result;
        }

    }
}
