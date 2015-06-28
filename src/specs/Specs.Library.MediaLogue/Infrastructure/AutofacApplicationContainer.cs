using System.Linq;
using System.Web.Http;
using Autofac;
using MediaLogue.Api.Core.Config;
using Specify;

namespace Specs.Library.MediaLogue.Infrastructure
{
    public class AutofacApplicationContainer : AutofacScenarioContainer, IApplicationContainer
    {
        public AutofacApplicationContainer() 
            : base(CreateContainer()) { }

        public IScenarioContainer CreateChildContainer()
        {
            return new AutofacScenarioContainer(Container.BeginLifetimeScope());
        }

        private static ContainerBuilder CreateContainer()
        {
            var builder = new AutofacContainerBuilder(new HttpConfiguration())
                .ConfigureBuilder();
            var assemblies = AssemblyTypeResolver.GetAllAssembliesFromAppDomain().ToArray();
            builder.RegisterAssemblyModules(assemblies);
            return builder;
        }
    }
}