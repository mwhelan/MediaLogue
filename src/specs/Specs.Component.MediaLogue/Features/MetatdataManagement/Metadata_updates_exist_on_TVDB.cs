using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class Metadata_updates_exist_on_TVDB : ScenarioFor<WebApiDriver, MetadataManagementStory>
    {
        public Metadata_updates_exist_on_TVDB()
        {
            Number = 4;
        }
        public void Given_a_configured_period_has_elapsed_since_the_last_update() { throw new NotImplementedException(); }
        public void AndGiven_Shows_exist_in_the_database() { throw new NotImplementedException(); }
        public void AndGiven_updates_to_metadata_exist_on_TVDB() { throw new NotImplementedException(); }
        public void When_I_request_those_updates() { throw new NotImplementedException(); }
        public void Then_I_update_the_Show_metadata() { throw new NotImplementedException(); }
    }
}