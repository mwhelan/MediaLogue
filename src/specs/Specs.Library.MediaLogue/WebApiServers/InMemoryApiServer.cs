using System;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using MediaLogue.Api.Core.Config;

namespace Specs.Library.MediaLogue.WebApiServers
{
    public class InMemoryApiServer : IApiServer
    {
        private readonly HttpConfiguration _config;

        private HttpServer _server;
        public Uri BaseAddress { get { return new Uri("http://localhost"); } }
        public HttpMessageHandler ServerHandler { get { return _server; } }
        public ApiServerHost Kind { get { return ApiServerHost.InMemory; } }

        public InMemoryApiServer(HttpConfiguration config)
        {
            _config = config;
        }

        public void Start()
        {
            try
            {
                _server = new HttpServer(_config);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not create server: {0}", e);
            }
        }

        public void Stop()
        {
            try
            {
                _server.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not stop server: {0}", e);
            }
        }
    }
}