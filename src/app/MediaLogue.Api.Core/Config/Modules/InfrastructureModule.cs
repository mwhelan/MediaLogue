using Autofac;
using MediaLogue.Api.Core.Config.Settings;
using MediaLogue.Domain.Contracts;
using MediaLogue.Infrastructure.Data;
using MediaLogue.Infrastructure.Data.Tvdb;

namespace MediaLogue.Api.Core.Config.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var connectionString = AppSettings.Settings.DatabaseConnectionString;
            builder.Register(c => new MediaLogueContext(connectionString))
                .As<IMediaLogueContext>()
                .InstancePerHttpRequest();
            builder.RegisterType<TvdbMapper>().As<ITvdbMapper>();
            builder.RegisterType<TvdbGateway>().As<ITvdbGateway>();
            builder.RegisterType<AsyncClient>().As<IWebClient>();
        }
    }
}