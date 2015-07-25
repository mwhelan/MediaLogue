using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.ImageManagement
{
    public class Generate_Thumbnail_Images : ScenarioFor<WebApiDriver,ImageManagementStory>
    {
        public Generate_Thumbnail_Images()
        {
            Number = 1;
        }
        public void Given_a_configured_period_has_elapsed_since_the_last_Thumbnail_Generation() { throw new NotImplementedException(); }
        public void AndGiven_there_are_requests_for_thumbnails_to_be_generated() { throw new NotImplementedException(); }
        public void When_I_generate_a_Thumbnail_for_a_Show() { throw new NotImplementedException(); }
        public void Then_the_Thumbnail_is_created() { throw new NotImplementedException(); }
        public void And_linked_with_the_Show() { throw new NotImplementedException(); }
    }
}