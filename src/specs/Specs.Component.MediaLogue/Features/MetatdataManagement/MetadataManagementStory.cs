using Specify.Stories;

namespace Specs.Component.MediaLogue.Features.MetatdataManagement
{
    public class MetadataManagementStory : UserStory
    {
        public MetadataManagementStory()
        {
            Title = "Metadata management";
            AsA = "As an API User";
            IWant = "I want to have the latest metadata about my Shows";
            SoThat = "So that I can choose whether to watch a TV Show";
        }
    }
}