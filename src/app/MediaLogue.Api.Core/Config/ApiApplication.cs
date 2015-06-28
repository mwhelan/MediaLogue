using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace MediaLogue.Api.Core.Config
{
    public class ApiApplication : IApiApplication
    {
        public HttpConfiguration Configuration { get; private set; }
        public IContainer Container { get; private set; }

        public ApiApplication(HttpConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(Action<ContainerBuilder> modifier = null)
        {
            ConfigureRoutes();
            ConfigureDependencies(modifier);
        }

        private void ConfigureDependencies(Action<ContainerBuilder> modifier = null)
        {
            var builder = new ContainerBuilder();
            builder.RegisterHttpRequestMessage(Configuration);
            builder.Register(c => Configuration.Routes).As<HttpRouteCollection>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder
            //    .RegisterAssemblyTypes(typeof(AutofacContainerBuilder).Assembly)
            //    .AsImplementedInterfaces();

            //builder.RegisterAssemblyModules(typeof(AutofacContainerBuilder).Assembly);

            if (modifier != null)
            {
                modifier(builder);
            }

            Container = builder.Build();
            Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        private void ConfigureRoutes()
        {
            Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }
    }
}