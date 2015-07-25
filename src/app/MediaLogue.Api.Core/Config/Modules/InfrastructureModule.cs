using System;
using System.Configuration;
using System.Net.Http;
using System.Web;
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
            var connectionString = GetConnectionString();
            builder.Register(c => new MediaLogueContext(connectionString))
                .As<IMediaLogueContext>()
                .InstancePerHttpRequest();
            builder.RegisterType<TvdbMapper>().As<ITvdbMapper>();
            builder.RegisterType<TvdbGateway>().As<ITvdbGateway>();
            builder.RegisterType<AsyncClient>().As<IWebClient>();
        }

        private static string GetConnectionString()
        {
#if DEBUG
            return ConfigurationManager.ConnectionStrings["MediaLogueConnectionStringLocal"].ConnectionString;
#else
            return ConfigurationManager.ConnectionStrings["MediaLogueConnectionString"].ConnectionString;
#endif
        }


    }
}