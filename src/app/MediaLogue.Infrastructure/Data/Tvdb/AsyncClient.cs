using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public class AsyncClient : IWebClient
    {
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            try
            {
                var uri = new Uri(url);

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(7);

                    var response = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new BadResponseException(response.StatusCode);
                    }

                    return response;
                }
            }
            catch (Exception e)
            {
                throw new ServerNotAvailableException(inner: e);
            }
        }
    }
}