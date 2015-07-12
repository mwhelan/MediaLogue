using System.Web;
using System.Web.Http;
using MediaLogue.Api.Core.Config;

namespace MediaLogue.Api.WebHost
{
    public class Global : HttpApplication
    {
        //private static readonly ApiApplication WebApiConfig = new ApiApplication(GlobalConfiguration.Configuration);

        protected void Application_Start()
        {
            var application = new ApiApplication(GlobalConfiguration.Configuration);
            application.Configure();
        }
    }
}