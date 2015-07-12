using TestStack.ConventionTests;
using TestStack.ConventionTests.Reporting;

[assembly: ConventionReporter(typeof(HtmlConventionResultsReporter))]
[assembly: ConventionReporter(typeof(MarkdownConventionResultsReporter))]

namespace Specs.Integration.MediaLogue.Conventions
{
    using Specify.Stories;

    public class ConventionsStory : Story
    {
        public ConventionsStory()
        {
            this.Title = "Application Conventions";
            this.TitlePrefix = string.Empty;
        }
    }
}