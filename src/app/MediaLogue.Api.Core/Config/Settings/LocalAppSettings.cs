namespace MediaLogue.Api.Core.Config.Settings
{
    public class LocalAppSettings : IAppSettings
    {
        public LocalAppSettings()
        {
            WebApiBaseUrl = "InMemory";
            DatabaseConnectionString = "Server=.;Database=MediaLogueDB-IntegrationSpecs;Trusted_Connection=True;";
        }
        public string WebApiBaseUrl { get; private set; }
        public string DatabaseConnectionString { get; private set; }
    }
}