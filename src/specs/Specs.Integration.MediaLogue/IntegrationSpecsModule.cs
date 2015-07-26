using Autofac;
using MediaLogue.Domain.Contracts;
using Specs.Library.MediaLogue.TestData.Stubs;

namespace Specs.Integration.MediaLogue
{
    public class IntegrationSpecsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StubTvdbGateway>().As<ITvdbGateway>();
        }
    }
}
