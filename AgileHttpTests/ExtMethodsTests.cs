using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AgileHttp;
using System.Threading.Tasks;

namespace AgileHttpTests
{
    [TestClass]
    public class ExtMethodsTests
    {
        [TestMethod()]
        public void AppendQueryStringTest()
        {
            var str = "";
            var url = str.AppendQueryString("a", "1");
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?a=1");

            str = "?";
            url = str.AppendQueryString("a", "1");
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?a=1");

            str = "?f=1";
            url = str.AppendQueryString("a", "1");
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?f=1&a=1");

            str = "?f=1&";
            url = str.AppendQueryString("a", "1");
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?f=1&a=1");
        }

        [TestMethod()]
        public void AppendQueryStringsTest()
        {
            var qs = new Dictionary<string, string>();
            var str = "";
            var url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url,"?");

            qs.Add("a", "1");
            qs.Add("b","2");
            str = "";
            url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?a=1&b=2");

            str = "?";
            url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?a=1&b=2");

            str = "?f=1";
            url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?f=1&a=1&b=2");

            str = "?f=1&";
            url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?f=1&a=1&b=2");
        }

        [TestMethod()]
        public void AsHttpTest()
        {
            var result = "https://www.baidu.com"
                .AppendQueryString("name", "U")
                .AsHttp("GET")
                .Send()
                .GetResponseContent();
            Assert.IsNotNull(result);

           result = "https://www.baidu.com"
               .AppendQueryString("name", "U")
               .AsHttp("POST",new RequestSetting { Body = Encoding.UTF8.GetBytes("hahahaha") } )
               .Send()
               .GetResponseContent();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AsHttpGetTest()
        {
            var response = "https://www.baidu.com"
                .AsHttp()
                .Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpPostTest()
        {
            var response = "https://www.baidu.com".AsHttp("POST").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpPutTest()
        {
            var response = "https://www.baidu.com".AsHttp("PUT").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpDeleteTest()
        {
            var response = "https://www.baidu.com".AsHttp("DELETE").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpOptionsTest()
        {
            var response = "https://www.baidu.com".AsHttp("OPTIONS").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }


        [TestMethod()]
        public async Task AsHttpGetTestAsync()
        {
            var response = await "https://www.baidu.com".AsHttp().SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpPostTestAsync()
        {
            var response = await "https://www.baidu.com".AsHttp("POST").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpPutTestAsync()
        {
            var response = await "https://www.baidu.com".AsHttp("PUT").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpDeleteTestAsync()
        {
            var response = await "https://www.baidu.com".AsHttp("DELETE").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpOptionsTestAsync()
        {
            var response = await "https://www.baidu.com".AsHttp("OPTIONS").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Console.WriteLine(content);
        }
    }
}
