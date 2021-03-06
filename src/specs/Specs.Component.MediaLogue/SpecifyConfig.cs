﻿using Specify;
using Specify.Configuration;
using Specs.Library.MediaLogue.Ef;
using Specs.Library.MediaLogue.Infrastructure;

using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Reporters.Html;

namespace Specs.Component.MediaLogue
{
    public class SpecifyConfig : SpecifyBootstrapper
    {
        public SpecifyConfig()
        {
            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new ReportConfig()));
            LoggingEnabled = true;

            PerAppDomainActions.Add(new SetupDatabasePerAppDomain());
            PerTestActions.Add(new SetupDatabasePerScenario());
        }

        public override IApplicationContainer CreateApplicationContainer()
        {
            return new AutofacApplicationContainer();
        }

        private class ReportConfig : DefaultHtmlReportConfiguration
        {
            public override string ReportHeader
            {
                get { return "MediaLogue"; }
            }

            public override string ReportDescription
            {
                get { return "Component Specifications"; }
            }

            public override string OutputFileName
            {
                get { return "MediaLogue-ComponentSpecifications.html"; }
            }
        }
    }
}
