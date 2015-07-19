using Autofac;
using MediaLogue.Infrastructure.Data;
using MediaLogue.Infrastructure.Data.Tvdb;

namespace MediaLogue.Api.Core.Config.Modules
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (TvdbMapper).Assembly).AsImplementedInterfaces();
            builder.RegisterType<MediaLogueContext>().As<IMediaLogueContext>().InstancePerRequest();
        }
    }
}