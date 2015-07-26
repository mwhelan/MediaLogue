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
        private int _id;

        public void Given_a_valid_TVDB_ID()
        {
            _id = ShowData.TheFieldOfBlood.Id;
        }

        public void When_I_request_the_Show_from_TVDB()
        {
            SUT.Execute(Const.Urls.Tvdb.Get(_id));
        }

        public void Then_should_return_Show()
        {
            var show = SUT.Response.Content.ReadAsAsync<Show>().Result;
            show.Id.Should().Be(_id);
        }
    }
}
