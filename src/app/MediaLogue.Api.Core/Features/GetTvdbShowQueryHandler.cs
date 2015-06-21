using System.Threading.Tasks;
using MediaLogue.Core.Domain.Contracts;
using MediaLogue.Core.Domain.Model;
using MediatR;

namespace MediaLogue.Api.Core.Features
{
    public class GetTvdbShowQueryHandler : IAsyncRequestHandler<GetTvdbShowQuery, Show>
    {
        private readonly ITvdbGateway _gateway;
        private readonly ITvdbMapper _mapper;

        public GetTvdbShowQueryHandler(ITvdbGateway gateway, ITvdbMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public async Task<Show> Handle(GetTvdbShowQuery message)
        {
            var xml = await _gateway.GetShow(message.ShowId);
            var show = _mapper.MapShowFrom(xml);
            return show;
        }
    }
}