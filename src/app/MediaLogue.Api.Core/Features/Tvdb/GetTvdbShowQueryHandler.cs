using MediaLogue.Domain.Contracts;
using MediaLogue.Domain.Model;
using MediatR;

namespace MediaLogue.Api.Core.Features.Tvdb
{
    public class GetTvdbShowQueryHandler : IRequestHandler<GetTvdbShowQuery, Show>
    {
        private readonly ITvdbGateway _gateway;
        private readonly ITvdbMapper _mapper;

        public GetTvdbShowQueryHandler(ITvdbGateway gateway, ITvdbMapper mapper)
        {
            _gateway = gateway;
            _mapper = mapper;
        }

        public Show Handle(GetTvdbShowQuery message)
        {
            var xml = _gateway.GetShow(message.ShowId).Result;
            var show = _mapper.MapShowFrom(xml);
            return show;
        }
    }
}