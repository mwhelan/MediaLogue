using System.Net.Http;
using FluentAssertions;
using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.TestData;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class Have_show_metadata : ScenarioFor<WebApiDriver, MetadataManagementStory>
    {
        private Show _showToPersist;
        private Show _result;

        public Have_show_metadata()
        {
            Number = 1;
        }

        public void Given_Show_metadata()
        {
            _showToPersist = ShowData.Turn.Show
                .Persist(Container.Get<IMediaLogueContext>());
        }

        public void When_I_request_the_Show()
        {
            SUT.Execute(Const.Urls.Shows.Get(ShowData.Turn.Id));
            _result = SUT.Response.Content.ReadAsAsync<Show>().Result;
        }

        public void Then_the_Show_is_returned()
        {
            _result.ShouldBeEquivalentTo(_showToPersist);
        }

        public void AndThen_the_Show_has_a_full_size_image()
        {
            _result.PosterPath.Should().Be(_showToPersist.PosterPath);
        }

        public void AndThen_the_Show_has_a_thumbnail_image()
        {
            _result.PosterThumbPath.Should().Be(_showToPersist.PosterPath);
        }
    }
}