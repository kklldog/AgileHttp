using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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

            var json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public T Deserialize<T>(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var obj = JsonConvert.DeserializeObject<T>(content);
            return obj;
        }
    }
}
