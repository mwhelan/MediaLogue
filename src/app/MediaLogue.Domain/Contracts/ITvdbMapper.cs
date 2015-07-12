using MediaLogue.Domain.Model;

namespace MediaLogue.Domain.Contracts
{
    public interface ITvdbMapper
    {
        Show MapShowFrom(string xml);
    }
}