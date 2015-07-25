using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Contracts.Services;
using MediaLogue.Domain.Model;

namespace MediaLogue.Domain.Services
{
    public class TvdbService : ITvdbService
    {
        private readonly ITvdbGateway _gateway;
        private readonly ITvdbMapper _mapper;

        public TvdbService(ITvdbGateway gateway, ITvdbMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public Show GetShow(int id)
        {
            var xml = _gateway.GetShow(id).Result;
            var show = _mapper.MapShowFrom(xml);
            return show;
        }
    }
}
