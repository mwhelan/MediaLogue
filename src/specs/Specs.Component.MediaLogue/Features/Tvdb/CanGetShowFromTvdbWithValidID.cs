using System.Net.Http;

using FluentAssertions;

using MediaLogue.Domain.Model;

using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.TestData;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.Tvdb
{
    public class CanGetShowFromTvdbWithValidId : ScenarioFor<WebApiDriver,TvdbStory>
    {
        private string _url;

        public void Given_a_valid_TVDB_ID()
        {
            _url = Const.Urls.Tvdb_GetShow(ShowData.TheFieldOfBlood.Id);
        }

        public void When_I_request_the_Show_from_TVDB()
        {
            SUT.Execute(_url);
        }

        public void Then_should_return_Show()
        {
            var show = SUT.Response.Content.ReadAsAsync<Show>().Result;
            show.Id.Should().Be(ShowData.TheFieldOfBlood.Id);
        }
    }
}
