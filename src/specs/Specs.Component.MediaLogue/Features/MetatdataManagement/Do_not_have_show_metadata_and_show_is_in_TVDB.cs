using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class Do_not_have_show_metadata_and_show_is_in_TVDB : ScenarioFor<WebApiDriver, MetadataManagementStory>
    {
        public Do_not_have_show_metadata_and_show_is_in_TVDB()
        {
            Number = 2;
        }

        public void Given_that_the_Show_does_not_exist_in_the_database()
        {
            throw new NotImplementedException();
            
        }
        public void AndGiven_the_show_exists_in_TVDB() { throw new NotImplementedException(); }
        public void When_I_request_the_Show() { throw new NotImplementedException(); }
        public void Then_the_Show_is_returned() { throw new NotImplementedException(); }
        public void AndThen_the_Show_has_a_full_size_image() { throw new NotImplementedException(); }
        public void AndThen_the_Show_does_not_have_a_thumbnail_image() { throw new NotImplementedException(); }
        public void AndThen_a_Thumbnail_Generation_is_initiated() { throw new NotImplementedException(); }
    }
}