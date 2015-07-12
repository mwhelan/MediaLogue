using System.Net.Http;
using System.Threading.Tasks;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public interface IWebClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}