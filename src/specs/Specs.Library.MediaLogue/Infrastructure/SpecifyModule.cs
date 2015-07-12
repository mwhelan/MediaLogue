using System.Linq;
using Autofac;
using Specify;

namespace Specs.Library.MediaLogue.Infrastructure
{
    public class SpecifyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = AssemblyTypeResolver.GetAllAssembliesFromAppDomain().ToArray();
            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(Specify.ScenarioFor<>));
            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(Specify.ScenarioFor<,>));

            builder.Register(c => new AutofacScenarioContainer(c.Resolve<ILifetimeScope>()))
                .As<IScenarioContainer>()
                .InstancePerLifetimeScope();

            //var mockFactory = new MockDetector().FindAvailableMock();
            //if (mockFactory == null)
            //{
            //    builder.Register(c => new AutofacScenarioContainer(c.Resolve<ILifetimeScope>()))
            //        .As<IScenarioContainer>()
            //        .InstancePerLifetimeScope();
            //}
            //else
            //{
            //    builder.Register(c => new AutofacAutoMockingContainer(mockFactory()))
            //        .As<IScenarioContainer>()
            //        .InstancePerLifetimeScope();
            //}
        }
    }

}
