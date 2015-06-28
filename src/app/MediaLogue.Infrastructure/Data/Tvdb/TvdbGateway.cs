using System;
using System.IO;
using System.Threading.Tasks;
using MediaLogue.Domain.Contracts;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public class TvdbGateway : ITvdbGateway
    {
        private readonly IWebClient _webClient;
        private readonly string _apiKey;

        private const string BaseUrl = "http://thetvdb.com";

        public TvdbGateway(IWebClient webClient, string apiKey= "1DC81E8C1C5740E0")
        {
            _webClient = webClient;
            _apiKey = apiKey;
        }

        public async Task<Stream> GetShowFull(int showId)
        {
            var url = string.Format("{0}/api/{1}/series/{2}/all/en.zip", BaseUrl, _apiKey, showId);
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStreamAsync();
        }

        public async Task<string> GetShow(int showId)
        {
            var url = string.Format("{0}/api/{1}/series/{2}/all/en.xml", BaseUrl, _apiKey, showId);
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SearchShowsByTitle(string title, int maxResults = 5)
        {
            if (title == null)
            {
                throw new ArgumentNullException(title);
            }

            var url = string.Format("{0}/api/GetSeries.php?seriesname={1}&language=en", BaseUrl, title);
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}