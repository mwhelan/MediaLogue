namespace Specs.Integration.MediaLogue
{
    using Specify.Configuration;

    using TestStack.BDDfy.Configuration;
    using TestStack.BDDfy.Reporters.Html;

    public class SpecifyConfig : SpecifyBootstrapper
    {
        public SpecifyConfig()
        {
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new ReportConfig()));
            this.LoggingEnabled = true;
        }

        private class ReportConfig : DefaultHtmlReportConfiguration
        {
            public override string ReportHeader
            {
                get { return "MediaLogue"; }
            }

            public override string ReportDescription
            {
                get { return "Integration Specifications"; }
            }

            public override string OutputFileName
            {
                get { return "MediaLogue-IntegrationSpecifications.html"; }
            }
        }
    }
}
