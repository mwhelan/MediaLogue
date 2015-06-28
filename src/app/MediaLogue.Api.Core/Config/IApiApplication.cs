using System;
using Autofac;

namespace MediaLogue.Api.Core.Config
{
    public interface IApiApplication
    {
        void Configure(Action<ContainerBuilder> modifier = null);
    }
}