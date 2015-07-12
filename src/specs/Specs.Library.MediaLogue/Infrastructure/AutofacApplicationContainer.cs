using System.Linq;
using System.Web.Http;
using Autofac;
using Specify;

namespace Specs.Library.MediaLogue.Infrastructure
{
    using global::MediaLogue.Api.Core.Config;

    public class AutofacApplicationContainer : AutofacScenarioContainer, IApplicationContainer
    {
        public AutofacApplicationContainer() 
            : base(CreateContainer()) { }

        public IScenarioContainer CreateChildContainer()
        {
            return new AutofacScenarioContainer(Container.BeginLifetimeScope());
        }

        private static IContainer CreateContainer()
        {
            var app = new ApiApplication(new HttpConfiguration());
            app.Configure(ConfigureContainer);
            return app.Container;
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblies = AssemblyTypeResolver.GetAllAssembliesFromAppDomain().ToArray();
            builder.RegisterAssemblyModules(assemblies);
        }
    }
}