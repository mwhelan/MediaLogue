using System.Web;
using Autofac;
using Autofac.Builder;

namespace MediaLogue.Api.Core.Config.Modules
{
    /// <summary>
    /// Some utility extensions for Autofac component registration
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Registers a component so all dependant components will resolve the same shared instance within the test
        /// lifetime scope.
        /// </summary>
        public static IRegistrationBuilder<TLimit, TActivatorData, TStyle> InstancePerHttpRequest<TLimit, TActivatorData, TStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TStyle> registration)
        {
            if (HttpContext.Current != null)
            {
                return registration.InstancePerRequest();
            }
            else
            {
                return registration.InstancePerLifetimeScope();
            }
        }
    }
}