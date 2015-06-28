using System;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using MediaLogue.Api.Core.Config;

namespace Specs.Library.MediaLogue.WebApiServers
{
    public class InMemoryApiServer : IApiServer
    {
        private readonly ILifetimeScope _container;
        private HttpServer _server;
        public Uri BaseAddress { get { return new Uri("http://localhost"); } }
        public HttpMessageHandler ServerHandler { get { return _server; } }
        public ApiServerHost Kind { get { return ApiServerHost.InMemory; } }

        public InMemoryApiServer(ILifetimeScope container)
        {
            _container = container;
        }

        public void Start()
        {
            try
            {
                var httpConfig = new HttpConfiguration();
                var apiConfig = new ApiApplication(httpConfig, _container);
                apiConfig.Configure();
                _server = new HttpServer(httpConfig);
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