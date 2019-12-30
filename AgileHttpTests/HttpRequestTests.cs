using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgileHttp.Tests
{
    [TestClass()]
    public class HttpRequestTests
    {
        [TestMethod()]
        public void GetResponseContentTest()
        {
            var result = AgileHttpRequest.Send("https://www.baidu.com", "GET");
            var str = result.GetResponseContent();
            Assert.IsNotNull(str);

            Console.WriteLine(str);
        }

        [TestMethod()]
        public async Task GetResponseContentTestAsync()
        {
            var result = await AgileHttpRequest.SendAsync("https://www.baidu.com", "GET");
            var str = await result.GetResponseContentAsync();
            Assert.IsNotNull(str);
            Console.WriteLine(str);
        }

        [TestMethod()]
        public void CreateRequestTest()
        {
            var url = "https://www.baidu.com";
            var req = AgileHttpRequest.CreateRequest(url, "GET");
            Assert.IsNotNull(req);

            Assert.AreEqual(req.WebRequest.Method, "GET");
            Assert.AreEqual(req.WebRequest.Address, url);

            var setting = new RequestSetting {
                Connection = "a",
                Host = "c",
                Accept = "d",
                UserAgent = "e",
                Referer = "f",
                ContentType = "g",
                Headers = new Dictionary<string, string>() {
                    { "a","1"}, { "b","2" }
                }
            };
            req = AgileHttpRequest.CreateRequest(url, "POST", setting);
            Assert.IsNotNull(req);

            Assert.AreEqual(req.WebRequest.Method, "POST");
            Assert.AreEqual(req.WebRequest.Address, url);

            Assert.AreEqual(req.WebRequest.Connection, setting.Connection);
            Assert.AreEqual(req.WebRequest.Host, setting.Host);
            Assert.AreEqual(req.WebRequest.Accept, setting.Accept);
            Assert.AreEqual(req.WebRequest.UserAgent, setting.UserAgent);
            Assert.AreEqual(req.WebRequest.Referer, setting.Referer);
            Assert.AreEqual(req.WebRequest.ContentType, setting.ContentType);

            Assert.AreEqual(req.WebRequest.Headers.Get("a"), "1");
            Assert.AreEqual(req.WebRequest.Headers.Get("b"), "2");
        }
    }
}