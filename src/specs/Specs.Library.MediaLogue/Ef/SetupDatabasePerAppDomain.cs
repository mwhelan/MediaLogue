using MediaLogue.Infrastructure.Data;
using Specify;
using Specify.Configuration;

namespace Specs.Library.MediaLogue.Ef
{
    public class SetupDatabasePerAppDomain : IPerAppDomainActions
    {
        public void Before(IApplicationContainer container)
        {
            container.Resolve<IMediaLogueContext>().Database.Initialize(true);
        }

        public void After()
        {
        }
    }
}