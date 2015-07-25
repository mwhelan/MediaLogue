using System.Configuration;
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
#if DEBUG
            var connectionString = ConfigurationManager.ConnectionStrings["MediaLogueConnectionStringLocal"].ConnectionString;
#else
            var connectionString = ConfigurationManager.ConnectionStrings["MediaLogueConnectionString"].ConnectionString;
#endif
            Checkpoint.Reset(connectionString);
        }

        public void After()
        {
        }
    }
}