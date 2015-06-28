using System.Linq;
using Autofac;
using Specify;
using Specify.Configuration;
using Specify.Configuration.Mocking;
using Specs.Library.MediaLogue.Infrastructure;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue
{
    public class ComponentSpecsBootstrapper : SpecifyBootstrapper
    {
        public override IApplicationContainer CreateApplicationContainer()
        {
            return new AutofacApplicationContainer();
        }
    }

    public class ComponentSpecsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryApiServer>().As<IApiServer>().SingleInstance()
                .OnActivated(x => x.Instance.Start())
                .OnRelease(x => x.Stop());
            builder.RegisterType<WebApiDriver>();
        }
    }
}
