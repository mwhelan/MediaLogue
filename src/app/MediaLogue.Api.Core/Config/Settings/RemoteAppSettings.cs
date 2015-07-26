using System.Configuration;

namespace MediaLogue.Api.Core.Config.Settings
{
    public class RemoteAppSettings : IAppSettings
    {
        public RemoteAppSettings()
        {
            WebApiBaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            DatabaseConnectionString = ConfigurationManager.ConnectionStrings["MediaLogueConnectionString"].ConnectionString;
        }
        public string WebApiBaseUrl { get; private set; }
        public string DatabaseConnectionString { get; private set; }
    }
}
