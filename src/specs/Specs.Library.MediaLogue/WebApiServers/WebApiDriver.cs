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
            if (httpMethod == null)
            {
                httpMethod = HttpMethod.Get;
            }
            var url = string.Format("{0}{1}", _server.BaseAddress, relativeUrl);

            var request = Requester.Create(httpMethod, url);
            Execute(request);
        }

        public IApiServer Server { get { return _server; }}

        public void Dispose()
        {
            //_server.Dispose();
        }
    }
}
