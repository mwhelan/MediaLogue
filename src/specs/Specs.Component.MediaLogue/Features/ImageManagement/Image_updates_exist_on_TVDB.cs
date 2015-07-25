using System;
using Specs.Library.MediaLogue;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue.Features.ImageManagement
{
    public class Image_updates_exist_on_TVDB : ScenarioFor<WebApiDriver,ImageManagementStory>
    {
        public Image_updates_exist_on_TVDB()
        {
            Number = 2;
        }
        public void Given_a_configured_period_has_elapsed_since_the_last_update() { throw new NotImplementedException(); }
        public void AndGiven_updates_to_images_exist_on_TVDB_for_my_Shows() { throw new NotImplementedException(); }
        public void When_I_request_those_updates() { throw new NotImplementedException(); }
        public void Then_I_get_the_updated_full_size_Show_image() { throw new NotImplementedException(); }
        public void AndThen_request_a_thumbnail_for_the_full_size_image() { throw new NotImplementedException(); }
    }
}