using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MediaLogue.Api.Core.Controllers;

namespace MediaLogue.Api.Core.Config
{
    public class AutofacConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config,
                RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {

            config.DependencyResolver =
                new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterApiControllers(typeof(TvdbController).Assembly);


            return builder.Build();
        }
    }
}