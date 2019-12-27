using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileHttp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgileHttp.Tests
{
    [TestClass()]
    public class HttpRequestTests
    {
        [TestMethod()]
        public void GetResponseContentTest()
        {
            var result = HttpRequest.DoRequest("https://www.baidu.com", "GET");
            var str = result.GetResponseContent();
            Assert.IsNotNull(str);

            Console.WriteLine(str);
        }

        [TestMethod()]
        public  void GetResponseContentTestAsync()
        {
            var result = HttpRequest.DoRequest("https://www.baidu.com", "GET");
            var task = result.GetResponseContentAsync();
            Assert.IsNotNull(task.Result);

            Console.WriteLine(task.Result);
        }

        [TestMethod()]
        public void RequestExtHttpTest() 
        {
            var result = "https://www.baidu.com".Http();
            var str = result.GetResponseContent();
            Assert.IsNotNull(str);

            Console.WriteLine(str);
        }

        [TestMethod()]
        public void RequestExtHttpTestAsync()
        {
            var task = "https://www.baidu.com".HttpAsync();
            var result = task.Result;
            Assert.IsNotNull(result);

            Console.WriteLine(result.GetResponseContent());
        }
    }
}