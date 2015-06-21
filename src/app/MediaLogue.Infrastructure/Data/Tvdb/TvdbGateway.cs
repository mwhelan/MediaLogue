using System;
using System.IO;
using System.Threading.Tasks;
using MediaLogue.Core.Domain.Contracts;

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
            var url = $"{BaseUrl}/api/{_apiKey}/series/{showId}/all/en.zip";
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStreamAsync();
        }

        public async Task<string> GetShow(int showId)
        {
            var url = $"{BaseUrl}/api/{_apiKey}/series/{showId}/all/en.xml";
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SearchShowsByTitle(string title, int maxResults = 5)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var url = $"{BaseUrl}/api/GetSeries.php?seriesname={title}&language=en";
            var response = await _webClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}