using Agile.AServer;
using System;

namespace AgileHttpTestServer
{
    public class TestModel
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var server = new Agile.AServer.Server();

            server.AddHandler(new HttpHandler()
            {
                Method = "GET",
                Path = "/api/gettest",
                Handler = (req, resp) =>
                {
                    string name = req.Query.name;
                    return resp.Write(string.IsNullOrEmpty(name) ? "ok" : name);
                }
            });

            server.AddHandler(new HttpHandler()
            {
                Method = "POST",
                Path = "/api/posttest",
                Handler = (req, resp) =>
                {
                    return resp.Write(string.IsNullOrEmpty(req.BodyContent) ? "ok" : req.BodyContent);
                }
            });

            server.AddHandler(new HttpHandler()
            {
                Method = "PUT",
                Path = "/api/puttest",
                Handler = (req, resp) =>
                {
                    return resp.Write(string.IsNullOrEmpty(req.BodyContent) ? "ok" : req.BodyContent);
                }
            });

            server.AddHandler(new HttpHandler()
            {
                Method = "DELETE",
                Path = "/api/deletetest",
                Handler = (req, resp) =>
                {
                    return resp.Write(string.IsNullOrEmpty(req.BodyContent) ? "ok" : req.BodyContent);
                }
            });

            server.AddHandler(new HttpHandler()
            {
                Method = "OPTIONS",
                Path = "/api/optionstest",
                Handler = (req, resp) =>
                {
                    return resp.Write(string.IsNullOrEmpty(req.BodyContent) ? "ok" : req.BodyContent);
                }
            });

            server.Run();

            Console.Read();
        }
    }
}
