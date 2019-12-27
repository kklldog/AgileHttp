using System;
using System.Collections.Generic;
using System.Text;

namespace AgileHttp.rest
{
    public interface IRestClient
    {
        T Get<T>(string url);


        T Post<T>(string url, object body);


        T Put<T>(string url, object body);


        T Delete<T>(string url);
       
    }
}
