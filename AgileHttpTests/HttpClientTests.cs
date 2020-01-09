using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileHttp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp.Tests
{
    [TestClass()]
    public class HttpClientTests
    {
        [TestMethod()]
        public void AsHttpClientGetTest()
        {
            var result = "http://localhost:5000/api/gettest"
              .AppendQueryString("name", "kklldog")
              .AsHttpClient()
              .Get()
              .GetResponseContent();
            Assert.IsNotNull(result);
            Assert.AreEqual(result, "kklldog");
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpClientPostTest()
        {
            var result = "http://localhost:5000/api/posttest"
               .AsHttpClient()
               .Post(new { name = "kklldog" })
               .GetResponseContent();
            Assert.IsNotNull(result);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpClientPost1Test()
        {
            var result = "http://localhost:5000/api/posttest"
             .AsHttpClient()
             .Post("hhh")
             .GetResponseContent();
            Assert.IsNotNull(result);
            Assert.AreEqual("hhh", result);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void AsHttpClientPost2Test()
        {
            var body = Encoding.UTF8.GetBytes("hhh");
            var result = "http://localhost:5000/api/posttest"
             .AsHttpClient()
             .Post(body)
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
        public void AsHttpClientPost3Test()
        {
            var result = "http://localhost:5000/api/posttest"
                .AsHttpClient()
                .Config(new RequestOptions
                {
                    ContentType = "application/json"
                })
                .Post<User>(new { name = "kklldog" });
            Assert.IsNotNull(result);
            string name = result.name;
            Assert.IsNotNull(name);
            Assert.AreEqual("kklldog", name);
            Console.WriteLine(result);
        }
        [TestMethod()]
        public void AsHttpClientPutTest()
        {
            var response = "http://localhost:5000/api/puttest".AsHttpClient().Put();
            Assert.IsNotNull(response);
            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpClientDeleteTest()
        {
            var response = "http://localhost:5000/api/deletetest".AsHttpClient().Delete();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public void AsHttpClientOptionsTest()
        {
            var response = "http://localhost:5000/api/optionstest".AsHttpClient().Options();
            Assert.IsNotNull(response);

            var content = response.GetResponseContent();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }


        [TestMethod()]
        public async Task AsHttpClientGetTestAsync()
        {
            var response = await "http://localhost:5000/api/gettest"
                .AppendQueryString("name", "")
                .AsHttpClient()
                .GetAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpClientPostTestAsync()
        {
            var response = await "http://localhost:5000/api/posttest".AsHttpClient().PostAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpClientPostTest1Async()
        {
            var result = await "http://localhost:5000/api/posttest"
                .AsHttpClient()
                .Config(new RequestOptions
                {
                    ContentType = "application/json"
                })
                .PostAsync<User>(new { name = "kklldog" });
            Assert.IsNotNull(result);
            string name = result.name;
            Assert.IsNotNull(name);
            Assert.AreEqual("kklldog", name);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public async Task AsHttpClientPutTestAsync()
        {
            var response = await "http://localhost:5000/api/puttest".AsHttpClient().PutAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpClientDeleteTestAsync()
        {
            var response = await "http://localhost:5000/api/deletetest".AsHttpClient().DeleteAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }

        [TestMethod()]
        public async Task AsHttpClientOptionsTestAsync()
        {
            var response = await "http://localhost:5000/api/optionstest".AsHttpClient().OptionsAsync();
            Assert.IsNotNull(response);

            var content = await response.GetResponseContentAsync();
            Assert.IsNotNull(content);
            Assert.AreEqual("ok", content);
            Console.WriteLine(content);
        }
    }
}