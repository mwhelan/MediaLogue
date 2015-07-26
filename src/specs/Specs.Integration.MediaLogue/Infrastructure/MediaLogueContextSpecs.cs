using System.Linq;
using FluentAssertions;
using MediaLogue.Domain.Contracts.Services;
using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.TestData;

namespace Specs.Integration.MediaLogue.Infrastructure
{
    public class MediaLogueContextSpecs : ScenarioFor<IMediaLogueContext>
    {
        private Show _showToPersist;
        private Show _result;

        public void Given_a_Show_with_five_episodes()
        {
            _showToPersist = Container.Get<ITvdbService>().GetShow(ShowData.Turn.Id);
        }

        public void When_it_is_added()
        {
            SUT.Shows.Add(_showToPersist);
            SUT.SaveChanges();
            _result = SUT.Shows.First(show => show.Id == ShowData.Turn.Id);
        }

        public void Then_the_Show_is_persisted()
        {
            _result.ShouldBeEquivalentTo(_showToPersist);
        }

        public void AndThen_the_Episodes_are_all_persisted()
        {
            foreach (var episode in _result.Episodes)
            {
                episode.ShouldBeEquivalentTo(_showToPersist.Episodes.First(ep => ep.Id == episode.Id));
            }
        }
    }
}
