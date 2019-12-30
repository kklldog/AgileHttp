using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgileHttp
{
    public static class ExtMethods
    {
        /// <summary>
        /// append the query stirngs to the url . ?a=1&b=2
        /// </summary>
        /// <param name="str"></param>
        /// <param name="queryStrings"></param>
        /// <returns></returns>
        public static string AppendQueryStrings(this string str, IDictionary<string, string> queryStrings)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = "";
            }

            var sb = new StringBuilder(str);
            if (!str.Contains("?"))
            {
                sb.Append("?");
            }
            if (!sb.ToString().EndsWith("?") && !sb.ToString().EndsWith("&"))
            {
                sb.Append("&");
            }

            foreach (var item in queryStrings)
            {
                var key = item.Key;
                var value = item.Value;

                sb.AppendFormat("{0}={1}&", key, value);
            }

            str = sb.ToString();
            if (str.EndsWith("&"))
            {
                str = str.Remove(str.Length - 1, 1);
            }

            return str;
        }

        /// <summary>
        /// append the query stirngs to the url . ?a=1&b=2
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string AppendQueryString(this string str, string key, string val)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = "";
            }

            var sb = new StringBuilder(str);
            if (!str.Contains("?"))
            {
                sb.Append("?");
            }

            if (!sb.ToString().EndsWith("?") && !sb.ToString().EndsWith("&"))
            {
                sb.Append("&");
            }

            sb.AppendFormat("{0}={1}", key, val);

            return sb.ToString();
        }

        /// <summary>
        /// create a http request base on this str 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="mehtod">GET method is default </param>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static RequestInfo AsHttp(this string str, string mehtod = "GET", RequestSetting setting = null)
        {
            return AgileHttpRequest.CreateRequest(str, mehtod, setting);
        }

        /// <summary>
        /// send the http request 
        /// </summary>
        /// <param name="requestInto"></param>
        /// <returns></returns>
        public static ResponseResult Send(this RequestInfo requestInto)
        {
            return AgileHttpRequest.Send(requestInto);
        }

        /// <summary>
        /// async send the http request 
        /// </summary>
        /// <param name="requestInto"></param>
        /// <returns></returns>
        public static Task<ResponseResult> SendAsync(this RequestInfo requestInto)
        {
            return AgileHttpRequest.SendAsync(requestInto);
        }

        /// <summary>
        /// Deserialize the http response content to type T , use default serialize provider .
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static T Deserialize<T>(this ResponseResult result)
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
                    var obj = AgileHttpRequest.DefaultSerializeProvider.Deserialize<T>(content);
                    return obj;
                }
            }
            return default(T);
        }
    }

}
