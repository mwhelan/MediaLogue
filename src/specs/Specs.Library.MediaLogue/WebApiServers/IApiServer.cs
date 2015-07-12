using System;
using System.Net.Http;

namespace Specs.Library.MediaLogue.WebApiServers
{
    public interface IApiServer
    {
        Uri BaseAddress { get; }
        ApiServerHost Kind { get; }
        HttpMessageHandler ServerHandler { get; }
        void Start();
        void Stop();
    }
}
