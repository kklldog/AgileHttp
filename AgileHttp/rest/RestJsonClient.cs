using AgileHttp.rest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AgileHttp.rest
{
    public class RestJsonClient: IRestClient
    {
        public T Get<T>(string url)
        {
            const string method = "GET";
            return DeserializeResult<T>(AgileHttpRequest.Send(url, method , new RequestSetting { 
                ContentType = "application/json; charset=utf-8"
            }));
        }

        public T Post<T>(string url, object body)
        {
            const string method = "POST";
            var setting = new RequestSetting
            {
                ContentType = "application/json; charset=utf-8"
            };
            if (body != null)
            {
                var json = JsonSerializer.Serialize(body);
                setting.Body = Encoding.UTF8.GetBytes(json);
            }

            return DeserializeResult<T>(AgileHttpRequest.Send(url, method, setting));
        }

        public T Put<T>(string url, object body)
        {
            const string method = "PUT";
            var setting = new RequestSetting
            {
                ContentType = "application/json; charset=utf-8"
            };
            if (body != null)
            {
                var json = JsonSerializer.Serialize(body);
                setting.Body = Encoding.UTF8.GetBytes(json);
            }

            return DeserializeResult<T>(AgileHttpRequest.Send(url, method, setting));
        }

        public T Delete<T>(string url)
        {
            const string method = "DELETE";
            var setting = new RequestSetting
            {
                ContentType = "application/json; charset=utf-8"
            };

            return DeserializeResult<T>(AgileHttpRequest.Send(url, method, setting));
        }


        private T DeserializeResult<T>(ResponseResult result) 
        {
            using (result)
            {
                return result.Deserialize<T>();
            }
        }
    }
}
