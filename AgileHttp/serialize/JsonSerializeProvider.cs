using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace AgileHttp.serialize
{
    public class JsonSerializeProvider : ISerializeProvider
    {
        public string Serialize(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var json = JsonSerializer.Serialize(obj);
            return json;
        }

        public T Deserialize<T>(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var obj = JsonSerializer.Deserialize<T>(content);
            return obj;
        }
    }
}
