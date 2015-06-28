using System.Web.Http;
using Specs.Library.MediaLogue.TestData;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue
{
    public class CanGetShowFromTvdbWithValidId : ScenarioFor<WebApiDriver,TvdbStory>
    {
        private int _tvdbId;
        private IHttpActionResult _result;

        public void Given_a_valid_TVDB_ID()
        {
            _tvdbId = ShowData.TheFieldOfBlood.Id;
        }

        public void When_I_request_the_show_from_TVDB()
        {
            var url = string.Format("http://www.nourl.com/api/tvdb/{0}", _tvdbId);
            SUT.Execute(url);
        }
    }
}
