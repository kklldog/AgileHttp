# AgileHttp
An aglie http client .
## 依赖 
Newtonsoft.Json 12.0.3 
## 安装 
Install-Package AgileHttp 
## 示例 
### 使用HTTP.Send方法 
使用HTTP.Send / HTTP.SendAsync方法可以直接发送一个请求   
```
HTTP.Send("http://www.baidu.com") // 默认为Get方法 
HTTP.Send("http://www.baidu.com", "POST")  
HTTP.Send("http://www.baidu.com", "POST", new { name = "mjzhou" })  
HTTP.Send("http://www.baidu.com", "POST", new { name = "mjzhou" }, new RequestOptions { ContentType = "application/json" }) 

ResponseInfo response = HTTP.Send("http://localhost:5000/api/user/1");
string content = response.GetResponseContent(); //获取http响应返回值的文本内容
```
HTTP.SendAsync方法是HTTP.Send方法的异步版本   
### 使用HttpClient类    
如果不喜欢手写"GET","POST","PUT"等HTTP方法，可以是使用HttpClient类。HttpClient类内置了GET,POST,PUT,DELETE,OPTIONS几个常用的方法。   
```
var client = new HttpClient("http://www.baidu.com");
client.Get();//使用HttpClient发送Get请求

var client = new HttpClient("http://www.baidu.com");
client.Config(new RequestOptions { ContentType = "application/json" });
client.Post(new { name = "mjzhou" }); //使用HttpClient发送Post请求

ResponseInfo response = new HttpClient("http://localhost:5000/api/user/1").Get();
string content = response.GetResponseContent(); //获取http响应返回值的文本内容
User user1 = new HttpClient("http://localhost:5000/api/user/1").Get<User>(); //泛型方法可以直接反序列化成对象。
```
Get,Post等方法都有异步版本GetAsync,PostAsync
### 关于序列化   
当你使用Post，Put（不限于这2个方法）方法提交一个对象的时候AgileHttp会自动就行序列化。使用泛型Get T, Post T方法会自动进行反序列化。默认使用JsonSerializeProvider来进行序列化及反序列化。JsonSerializeProvider使用著名的Newtonsoft.Json实现了ISerializeProvider接口，如果你喜欢你也可以自己实现自己的Provider，比如实现一个XMLSerializeProvider。
```
 public interface ISerializeProvider
  {
      T Deserialize<T>(string content);
      string Serialize(object obj);
  }
```
AgileHttp提供2个地方来修改SerializeProvider：   
1. 通过RequestOptions为单个Http请求配置序列化器
```
var xmlSerializeProvider = new xmlSerializeProvider();
var client = new HttpClient("http://www.baidu.com");
client.Config(new RequestOptions(xmlSerializeProvider));
```
2. 通过HTTP.SetDefaultSerializeProvider(ISerializeProvider provider)更改全局默认序列化器
```
var xmlSerializeProvider = new xmlSerializeProvider();
HTTP.SetDefaultSerializeProvider(xmlSerializeProvider);
```
注意！：如果提交的body参数的类型为String或者byte[]不会进行再次序列化。