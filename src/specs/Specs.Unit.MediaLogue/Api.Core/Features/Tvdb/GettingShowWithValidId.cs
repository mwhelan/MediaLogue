using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using MediaLogue.Api.Core.Features.Tvdb;
using MediaLogue.Domain.Model;
using MediatR;
using NSubstitute;
using Specs.Library.MediaLogue;
using TestStack.Dossier;
using TestStack.Dossier.EquivalenceClasses;

namespace Specs.Unit.MediaLogue.Api.Core.Features.Tvdb
{
    public class GettingShowWithValidId : ScenarioFor<TvdbController>
    {
        private IHttpActionResult _result;
        private int _tvdbId;
        private Show _show;

        public void Given_a_valid_TvdbId()
        {
            _tvdbId= Any.PositiveInteger();
            _show = Builder<Show>.CreateNew().Set(x => x.Id, _tvdbId);
            Container.Get<IMediator>().Send(Arg.Any<Get.Query>()).Returns(_show);
        }

        public void When_getting_Show_from_Tvdb()
        {
            _result = SUT.Get(_tvdbId);
        }

        public void Then_should_return_OK()
        {
            _result.Should().BeOfType<OkNegotiatedContentResult<Show>>();
        }

        public void AndThen_should_return_show_that_matches_Id()
        {
            ((OkNegotiatedContentResult<Show>) _result).Content.Should().Be(_show);
        }
    }
}