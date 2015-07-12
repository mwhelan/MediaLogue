namespace Specs.Component.MediaLogue.Features.Tvdb
{
    using System.Net.Http;

    using FluentAssertions;

    using global::MediaLogue.Domain.Model;

    using Specs.Library.MediaLogue;
    using Specs.Library.MediaLogue.TestData;
    using Specs.Library.MediaLogue.WebApiServers;

    public class CanGetShowFromTvdbWithValidId : ScenarioFor<WebApiDriver,TvdbStory>
    {
        public void Given_a_valid_TVDB_ID()
        {
        }

        public void When_I_request_the_Show_from_TVDB()
        {
            var url = Const.Urls.Tvdb_GetShow(ShowData.TheFieldOfBlood.Id);
            SUT.Execute(url);
        }

        public void Then_should_return_Show()
        {
            var show = this.SUT.Response.Content.ReadAsAsync<Show>().Result;
            show.Id.Should().Be(ShowData.TheFieldOfBlood.Id);
        }
    }
}
