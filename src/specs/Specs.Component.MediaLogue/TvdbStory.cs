using Specify.Stories;

namespace Specs.Component.MediaLogue
{
    public class TvdbStory : UserStory
    {
        public TvdbStory()
        {
            Title = "TVDB scenarios";
            AsA = "As an Application User";
            IWant = "I want to get Show data from TVDB";
            SoThat = "I can geek out on my favourite Shows";
        }
    }
}