using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp
{
    public class HttpClient
    {
        public string Url { get; private set; }
        public RequestInfo Request { get; private set; }
        public RequestOptions RequestOptions { get; private set; }

        public HttpClient(string url, RequestOptions options = null)
        {
            Url = url;
            RequestOptions = options;
        }

        public HttpClient Config(RequestOptions options)
        {
            RequestOptions = options;
            return this;
        }

        private ResponseInfo Do(string method, Object body)
        {
            Request = HTTP.CreateRequest(Url, method, body, RequestOptions);
            return HTTP.Send(Request);
        }
        /// <summary>
        /// Send a GET http request 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public ResponseInfo Get(Object body = null)
        {
            return Do("GET", body);
        }
        /// <summary>
        /// Send a POST http request 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public ResponseInfo Post(Object body = null)
        {
            return Do("POST", body);
        }
        /// <summary>
        /// Send a PUT http request 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public ResponseInfo Put(Object body = null)
        {
            return Do("PUT", body);
        }
        /// <summary>
        /// Send a DELETE http request 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public ResponseInfo Delete(Object body = null)
        {
            return Do("DELETE", body);
        }
        /// <summary>
        /// Send a OPTIONS http request 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public ResponseInfo Options(Object body = null)
        {
            return Do("OPTIONS", body);
        }
        /// <summary>
        /// Send a GET http request , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public T Get<T>(Object body = null)
        {
            using (var result = Do("GET", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a POST http request , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public T Post<T>(Object body = null)
        {
            using (var result = Do("POST", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a PUT http request , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public T Put<T>(Object body = null)
        {
            using (var result = Do("PUT", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a DELETE http request , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public T Delete<T>(Object body = null)
        {
            using (var result = Do("DELETE", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a OPTIONS http request , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public T Options<T>(Object body = null)
        {
            using (var result = Do("OPTIONS", body))
            {
                return result.Deserialize<T>();
            }
        }

        #region async
        private Task<ResponseInfo> DoAsync(string method, Object body)
        {
            Request = HTTP.CreateRequest(Url, method, body, RequestOptions);
            return HTTP.SendAsync(Request);
        }

        /// <summary>
        /// Send a GET http request Async
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<ResponseInfo> GetAsync(Object body = null)
        {
            return DoAsync("GET", body);
        }
        /// <summary>
        /// Send a POST http request Async
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<ResponseInfo> PostAsync(Object body = null)
        {
            return DoAsync("POST", body);
        }
        /// <summary>
        /// Send a PUT http request Async
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<ResponseInfo> PutAsync(Object body = null)
        {
            return DoAsync("PUT", body);
        }
        /// <summary>
        /// Send a DELETE http request Async
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<ResponseInfo> DeleteAsync(Object body = null)
        {
            return DoAsync("DELETE", body);
        }
        /// <summary>
        /// Send a OPTIONS http request Async
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public Task<ResponseInfo> OptionsAsync(Object body = null)
        {
            return DoAsync("OPTIONS", body);
        }
        /// <summary>
        /// Send a GET http request Async , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Object body = null)
        {
            using (var result = await DoAsync("GET", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a POST http request Async , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> PostAsync<T>(Object body = null)
        {
            using (var result = await DoAsync("POST", body))
            {
                return result.Deserialize<T>();
            } 
        }
        /// <summary>
        /// Send a PUT http request Async , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> PutAsync<T>(Object body = null)
        {
            using (var result = await DoAsync("PUT", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a DELETE http request Async , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> DeleteAsync<T>(Object body = null)
        {
            using (var result = await DoAsync("DELETE", body))
            {
                return result.Deserialize<T>();
            }
        }
        /// <summary>
        /// Send a OPTIONS http request Async , Then try to Deserialize 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> OptionsAsync<T>(Object body = null)
        {
            using (var result = await DoAsync("OPTIONS", body))
            {
                return result.Deserialize<T>();
            }
        }

        #endregion
    }
}
