using Specify.Configuration;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Reporters.Html;

namespace Specs.Unit.MediaLogue
{
    public class SpecifyConfig : SpecifyBootstrapper
    {
        public SpecifyConfig()
        {
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new ReportConfig()));
            LoggingEnabled = true;
        }

        private class ReportConfig : DefaultHtmlReportConfiguration
        {
            public override string ReportHeader
            {
                get { return "MediaLogue"; }
            }

            public override string ReportDescription
            {
                get { return "Unit Specifications"; }
            }

            public override string OutputFileName
            {
                get { return "MediaLogue-UnitSpecifications.html"; }
            }
        }
    }
}
