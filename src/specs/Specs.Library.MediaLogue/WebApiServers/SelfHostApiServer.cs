//using System;
//using System.Net.Http;
//using System.Web.Http;
//using MediaLogue.Api.Core.Config;

//namespace Specs.Library.MediaLogue.WebApiServers
//{
//    public class SelfHostApiServer : IApiServer
//    {
//        private HttpServer _server;

//        public Uri BaseAddress { get { return new Uri("http://localhost"); } }

//        public ApiServerHost Kind
//        {
//            get { return ApiServerHost.InMemory; }
//        }

//        public HttpMessageHandler ServerHandler { get { return _server; } }

//        public void Start()
//        {
//            try
//            {
//                //var httpConfig = new HttpSelfHostConfiguration(
//                //    new Uri("http://localhost:12345/"));
//                var httpConfig = new HttpConfiguration();
//                var apiConfig = new ApiApplication(httpConfig);
//                apiConfig.Configure();
//                _server = new HttpServer(httpConfig);
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Could not create server: {0}", e);
//            }
//        }

//        public void Stop()
//        {
//            try
//            {
//                _server.Dispose();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Could not stop server: {0}", e);
//            }
//        }
//    }
//}