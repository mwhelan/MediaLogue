using MediaLogue.Domain.Model;
using MediaLogue.Infrastructure.Data;

namespace Specs.Library.MediaLogue.TestData
{
    public static class PersistenceExtensions
    {
        public static Show Persist(this Show show, IMediaLogueContext context)
        {
            context.Shows.Add(show);
            context.SaveChanges();
            return show;
        }
    }
}