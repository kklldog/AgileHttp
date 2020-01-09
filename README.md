# AgileHttp
An aglie http client .
## 依赖 
Newtonsoft.Json 12.0.3 
## 安装 
Install-Package AgileHttp 
## 示例 
### 使用HTTP.Send方法 
使用HTTP.Send / HTTP.SendAsync方法可以直接发送一个请求   
```HTTP.Send("http://www.baidu.com") // 默认为Get方法```   
```HTTP.Send("http://www.baidu.com", "POST") ```   
```HTTP.Send("http://www.baidu.com", "POST", new { name = "mjzhou" }) ```   
```HTTP.Send("http://www.baidu.com", "POST", new { name = "mjzhou" }, new RequestOptions { ContentType = "application/json" }) ```   
HTTP.SendAsync方法是HTTP.Send方法的异步版本   
### 使用HttpClient类    
如果不喜欢手写"GET","POST","PUT"等HTTP方法，可以是使用HttpClient类。HttpClient类内置了GET,POST,PUT,DELETE,OPTIONS几个常用的方法。   
```
var client = new HttpClient("http://www.baidu.com");
client.Get();//使用HttpClient发送Get请求

var client = new HttpClient("http://www.baidu.com")
client.Config(new RequestOptions { ContentType = "application/json" });
client.Post(new { name = "mjzhou" }); //使用HttpClient发送Post请求
```
Get,Post等方法都有异步版本GetAsync,PostAsync
