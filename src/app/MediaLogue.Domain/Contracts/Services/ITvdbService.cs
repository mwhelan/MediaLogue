using MediaLogue.Domain.Model;

namespace MediaLogue.Domain.Contracts.Services
{
    public interface ITvdbService
    {
        Show GetShow(int id);
    }
}