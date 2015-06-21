using MediaLogue.Core.Domain.Model;

namespace MediaLogue.Core.Domain.Contracts
{
    public interface ITvdbMapper
    {
        Show MapShowFrom(string xml);
    }
}