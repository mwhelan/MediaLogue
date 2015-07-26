using System;
using System.Configuration;
using System.Diagnostics;
using System.Web.Http;
using Autofac;
using MediaLogue.Api.Core.Config.Settings;
using MediaLogue.Domain.Contracts;

using Specs.Library.MediaLogue.TestData.Stubs;
using Specs.Library.MediaLogue.WebApiServers;

namespace Specs.Component.MediaLogue
{
    public class ComponentSpecsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (AppSettings.Settings.WebApiBaseUrl == "InMemory")
            {
                builder.RegisterType<InMemoryApiServer>().As<IApiServer>().SingleInstance()
                    .OnActivated(x => x.Instance.Start())
                    .OnRelease(x => x.Stop());
            }
            else
            {
                var uri = new Uri(AppSettings.Settings.WebApiBaseUrl);
                builder.Register(c => new AspNetApiServer(uri)).SingleInstance();
            }

            builder.RegisterType<WebApiDriver>();
            builder.RegisterType<StubTvdbGateway>().As<ITvdbGateway>();
        }
    }
}
