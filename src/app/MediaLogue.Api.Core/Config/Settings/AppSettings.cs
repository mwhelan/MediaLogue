using System.Diagnostics;

namespace MediaLogue.Api.Core.Config.Settings
{
    public static class AppSettings
    {
        private static IAppSettings _settings;

        public static IAppSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    SetLocalSettings();
                    SetRemoteSettings();
                }
                return _settings;
            }
        }

        [Conditional("DEBUG")]
        private static void SetLocalSettings()
        {
            _settings = new LocalAppSettings();
        }

        [Conditional("RELEASE")]
        private static void SetRemoteSettings()
        {
            _settings = new RemoteAppSettings();
        }
    }
}