using System.Net;

using FluentAssertions;

using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.TestData;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.Tvdb
{
    public class CannotGetShowFromTvdbWithInvalidId : ScenarioFor<WebApiDriver, TvdbStory>
    {
        private string _url;

        public void Given_an_invalid_TVDB_ID()
        {
            _url = Const.Urls.Tvdb.Get(int.MaxValue);
        }

        public void When_I_request_the_Show_from_TVDB()
        {
            SUT.Execute(_url);
        }

        public void Then_should_not_return_not_Show()
        {
            SUT.Response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}