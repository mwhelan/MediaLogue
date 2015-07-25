using Autofac;
using MediaLogue.Domain.Contracts.Services;
using MediaLogue.Domain.Services;

namespace MediaLogue.Api.Core.Config.Modules
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TvdbService>().As<ITvdbService>();
        }
    }
}