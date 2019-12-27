using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgileHttp
{
    public static class ExtMethods
    {
        public static RequestResult Http(this string str, string mehtod = "GET", RequestSetting setting = null) 
        {
            return HttpRequest.DoRequest(str, mehtod, setting);
        }

        public static async Task<RequestResult> HttpAsync(this string str, string mehtod = "GET", RequestSetting setting = null)
        {
            return await HttpRequest.DoRequestAsync(str, mehtod, setting);
        }

        /// <summary>
        /// Deserialize the http result content to type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T DeserializeJson<T>(this RequestResult result)
        {
            if (result.Exception != null)
            {
                throw result.Exception;
            }
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = result.GetResponseContent();
                if (!string.IsNullOrEmpty(content))
                {
                    var obj = JsonSerializer.Deserialize<T>(content);
                    return obj;
                }
            }
            return default(T);
        }
    }

}
