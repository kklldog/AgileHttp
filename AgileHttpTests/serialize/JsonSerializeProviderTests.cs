using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileHttp.serialize;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgileHttp.serialize.Tests
{
    public class TestModel 
    { 
        public string Name { get; set; }

        public int? Age { get; set; }

        public DateTime Birth { get; set; }

        public bool Dead { get; set; }
    }

    [TestClass()]
    public class JsonSerializeProviderTests
    {
        [TestMethod()]
        public void DeserializeTest()
        {
            var json = "{\"Name\":\"user1\",\"Age\":1,\"Birth\":\"2019-12-31T12:12:12\",\"Dead\":false}";
            var user1 = new JsonSerializeProvider().Deserialize<TestModel>(json);
            Assert.IsNotNull(user1);
        }

        [TestMethod()]
        public void SerializeTest()
        {
            var model = new TestModel {
                Name = "user1",
                Age = 1,
                Birth = DateTime.Now,
                Dead = false
            };

            var json = new JsonSerializeProvider().Serialize(model);
            Assert.IsNotNull(json);
            Console.WriteLine(json);

        }
    }
}