using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using MediaLogue.Api.Core.Features.Tvdb;
using MediaLogue.Domain.Model;
using MediatR;
using NSubstitute;
using Specs.Library.MediaLogue;
using TestStack.Dossier.EquivalenceClasses;

namespace Specs.Unit.MediaLogue.Api.Core.Features.Tvdb
{
    public class GettingShowWithInvalidId : ScenarioFor<TvdbController>
    {
        private IHttpActionResult _result;

        public void Given_an_invalid_TvdbId()
        {
            Container.Get<IMediator>().Send(Arg.Any<Get.Query>()).Returns((Show)null);
        }

        public void When_getting_Show_from_Tvdb()
        {
            _result = SUT.Get(Any.PositiveInteger());
        }

        public void Then_should_return_NotFound()
        {
            _result.Should().BeOfType<NotFoundResult>();
        }
    }
}
