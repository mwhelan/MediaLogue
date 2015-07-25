using Specify.Stories;

namespace Specs.Component.MediaLogue.Features.Diagnostics
{
    public class DiagnosticsStory : UserStory
    {
        public DiagnosticsStory()
        {
            Title = "Diagnostics";
            AsA = "As a DevOps User";
            IWant = "I want to have application logs";
            SoThat = "So that I can know the application's availability, performance, and usage";
        }
    }
}
