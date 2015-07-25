using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class Do_not_have_show_metadata_and_show_is_not_in_TVDB:ScenarioFor<WebApiDriver, MetadataManagementStory>
    {
        public Do_not_have_show_metadata_and_show_is_not_in_TVDB()
        {
            Number = 3;
        }
        public void Given_that_the_Show_does_not_exist_in_the_database() { throw new NotImplementedException(); }
        public void AndGiven_the_show_does_not_exist_in_TVDB() { throw new NotImplementedException(); }
        public void When_I_request_the_Show() { throw new NotImplementedException(); }
        public void Then_an_error_is_returned_() { throw new NotImplementedException(); }
    }
}
