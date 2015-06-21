using System.Threading.Tasks;
using MediaLogue.Core.Domain.Contracts;
using MediaLogue.Core.Domain.Model;

namespace MediaLogue.Core.Domain.Services
{
    public interface ITvdbService
    {
        Task<Show> GetShow(int id);
    }

    public class TvdbService : ITvdbService
    {
        private readonly ITvdbGateway _gateway;
        private readonly ITvdbMapper _mapper;

        public TvdbService(ITvdbGateway gateway, ITvdbMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public async Task<Show> GetShow(int id)
        {
            var xml = await _gateway.GetShow(id);
            var show = _mapper.MapShowFrom(xml);
            return show;
        }
    }
}
