namespace Specs.Library.MediaLogue.TestData.Stubs
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using global::MediaLogue.Domain.Contracts;

    public class StubTvdbGateway : ITvdbGateway
    {
        public Task<Stream> GetShowFull(int showId)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetShow(int showId)
        {
            var show = TestData.ShowData.ShowStubs.FirstOrDefault(x => x.Id == showId);
            return show == null ? null : Task.FromResult(show.FullSeriesXml);
        }

        public Task<string> SearchShowsByTitle(string title, int maxResults = 5)
        {
            throw new NotImplementedException();
        }
    }
}
