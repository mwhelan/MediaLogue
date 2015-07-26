namespace MediaLogue.Api.Core.Config.Settings
{
    public interface IAppSettings
    {
        string WebApiBaseUrl { get; }
        string DatabaseConnectionString { get; }
    }
}