using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using Autofac;
using Autofac.Features.Variance;
using MediatR;

namespace MediaLogue.Api.Core.Config.Modules
{
    using MediaLogue.Api.Core.Features.Tvdb;

    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Get.Handler).Assembly).AsImplementedInterfaces();
            builder.RegisterInstance(Console.Out).As<TextWriter>();
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}
