using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class Have_show_metadata : ScenarioFor<WebApiDriver, MetadataManagementStory>
    {
        public Have_show_metadata()
        {
            Number = 1;
        }
        public void Given_Show_metadata() { throw new NotImplementedException();}
        public void When_I_request_the_Show() { throw new NotImplementedException();}
        public void Then_the_Show_is_returned() { throw new NotImplementedException();}
        public void AndThen_the_Show_has_a_full_size_image() { throw new NotImplementedException();}
        public void AndThen_the_Show_has_a_thumbnail_image() { throw new NotImplementedException();}
    }
}