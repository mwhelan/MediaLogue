using System.Configuration;
using MediaLogue.Api.Core.Config.Settings;
using Respawn;
using Specify;
using Specify.Configuration;

namespace Specs.Library.MediaLogue.Ef
{
    public class SetupDatabasePerScenario : IPerScenarioActions
    {
        private static readonly Checkpoint Checkpoint = new Checkpoint { TablesToIgnore = new[] {"sysdiagrams"} };

        public void Before(IScenarioContainer container)
        {
            Checkpoint.Reset(AppSettings.Settings.DatabaseConnectionString);
        }

        public void After()
        {
        }
    }
}