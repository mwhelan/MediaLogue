using System;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using Specs.Library.MediaLogue.WebApi;

namespace Specs.Library.MediaLogue.WebApiServers
{
    public class WebApiDriver : IDisposable 
    {
        private readonly IApiServer _server;
        public Exception Exception { get; set; }
        public HttpResponseMessage Response { get; set; }

        public WebApiDriver(IApiServer server)
        {
            _server = server;
        }

        public virtual void Execute(HttpRequestMessage request)
        {
            try
            {
                var client = new HttpClient(_server.ServerHandler);
                Response = client.SendAsync(request).Result;
            }
            catch (Exception ex)
            {
                Exception = ex;
                if (Exception is NotImplementedException) throw ex;
            }
        }

        public virtual void Execute(string relativeUrl, HttpMethod httpMethod = null)
        {
            var request = Requester.Create(_server.BaseAddress.OriginalString, relativeUrl,httpMethod);
            Execute(request);
        }

        public IApiServer Server { get { return _server; }}

        public void Dispose()
        {
            //_server.Dispose();
        }
    }
}
