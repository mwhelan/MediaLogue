using Autofac;

using MediaLogue.Domain.Contracts;

using Specs.Library.MediaLogue.TestData.Stubs;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue
{
    public class ComponentSpecsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryApiServer>().As<IApiServer>().SingleInstance()
                .OnActivated(x => x.Instance.Start())
                .OnRelease(x => x.Stop());
            builder.RegisterType<WebApiDriver>();
            builder.RegisterType<StubTvdbGateway>().As<ITvdbGateway>();
        }
    }
}
