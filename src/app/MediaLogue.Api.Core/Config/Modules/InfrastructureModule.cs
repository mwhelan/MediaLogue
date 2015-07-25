using Autofac;
using MediaLogue.Domain.Contracts;
using MediaLogue.Infrastructure.Data;
using MediaLogue.Infrastructure.Data.Tvdb;

namespace MediaLogue.Api.Core.Config.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MediaLogueContext>().As<IMediaLogueContext>().InstancePerRequest();
            builder.RegisterType<TvdbMapper>().As<ITvdbMapper>();
            builder.RegisterType<TvdbGateway>().As<ITvdbGateway>();
            builder.RegisterType<AsyncClient>().As<IWebClient>();
        }
    }
}