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

            str = "";
            url = str.AppendQueryString("a", "1")
                .AppendQueryString("b", "2");
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?a=1&b=2");
        }

        [TestMethod()]
        public void AppendQueryStringsTest()
        {
            var qs = new Dictionary<string, object>();
            var str = "";
            var url = str.AppendQueryStrings(qs);
            Assert.IsNotNull(url);
            Assert.AreEqual(url, "?");

            qs.Add("a", "1");
            qs.Add("b", "2");
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
        public void AsHttpGetTest()
        {
            var result = "http://localhost:5000/api/gettest"
              .AppendQueryString("name", "kklldog")
              .AsHttp()
              .Send()
              .GetResponseContent();
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "kklldog");
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpPostTest()
        {
            var result = "http://localhost:5000/api/posttest"
               .AsHttp("POST", new { name = "kklldog" })
               .Send()
               .GetResponseContent();
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpPost1Test()
        {
            var result = "http://localhost:5000/api/posttest"
             .AsHttp("POST", "hhh")
             .Send()
             .GetResponseContent();
            Assert.IsNotNull(result);
            Assert.AreEqual("hhh", result);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpPost2Test()
        {
            var body = Encoding.UTF8.GetBytes("hhh");
            var result = "http://localhost:5000/api/posttest"
             .AsHttp("POST", body)
             .Send()
             .GetResponseContent();
            Assert.IsNotNull(result);
            Assert.AreEqual("hhh", result);
            Console.WriteLine(result);
        }

        class User
        {
            public string name { get; set; }
        }

        [TestMethod()]
        public void AsHttpPost3Test()
        {
            var result = "http://localhost:5000/api/posttest"
                .AsHttp("POST", new { name = "kklldog" })
                .Config(new RequestOptions
                {
                    ContentType = "application/json"
                })
                .Send()
                .Deserialize<User>();
            Assert.IsNotNull(result);
            string name = result.name;
            Assert.IsNotNull(name);
            Assert.AreEqual("kklldog", name);
            Console.WriteLine(result);
        }
        [TestMethod()]
        public void AsHttpPutTest()
        {
            var response = "http://localhost:5000/api/puttest".AsHttp("PUT").Send();
            Assert.IsNotNull(response);
            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpDeleteTest()
        {
            var response = "http://localhost:5000/api/deletetest".AsHttp("DELETE").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpOptionsTest()
        {
            var response = "http://localhost:5000/api/optionstest".AsHttp("OPTIONS").Send();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }


        [TestMethod()]
        public async Task AsHttpGetTestAsync()
        {
            var response = await "http://localhost:5000/api/gettest"
                .AppendQueryString("name", "")
                .AsHttp()
                .SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpPostTestAsync()
        {
            var response = await "http://localhost:5000/api/posttest".AsHttp("POST").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpPostTest1Async()
        {
            var response = await "http://localhost:5000/api/posttest"
                .AsHttp("POST", new { name = "kklldog" })
                .Config(new RequestOptions
                {
                    ContentType = "application/json"
                })
                .SendAsync();
            var result = response.Deserialize<User>();
            Assert.IsNotNull(result);
            string name = result.name;
            Assert.IsNotNull(name);
            Assert.AreEqual("kklldog", name);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public async Task AsHttpPutTestAsync()
        {
            var response = await "http://localhost:5000/api/puttest".AsHttp("PUT").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpDeleteTestAsync()
        {
            var response = await "http://localhost:5000/api/deletetest".AsHttp("DELETE").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpOptionsTestAsync()
        {
            var response = await "http://localhost:5000/api/optionstest".AsHttp("OPTIONS").SendAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }
    }
}
