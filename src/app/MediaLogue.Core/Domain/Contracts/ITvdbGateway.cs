using System.IO;
using System.Threading.Tasks;

namespace MediaLogue.Core.Domain.Contracts
{
    public interface ITvdbGateway
    {
        /// <summary>
        ///     Retrieves the complete show with the given id and returns a zip file.
        /// </summary>
        /// <param name="showId">Id of the show you wish to lookup.</param>
        Task<Stream> GetShowFull(int showId);

        /// <summary>
        ///     Retrieves the show with the given id and returns the xml string.
        /// </summary>
        /// <param name="showId">Id of the show you wish to lookup.</param>
        Task<string> GetShow(int showId);

        /// <summary>
        ///     Returns the xml string representing a search response for the given parameter.
        /// </summary>
        /// <param name="title">Query to perform the search with. E.g. series title.</param>
        /// <param name="maxResults">Maximum amount of results to return. Default is 5</param>
        Task<string> SearchShowsByTitle(string title, int maxResults = 5);
    }
}
